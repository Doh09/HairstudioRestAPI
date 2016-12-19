using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HSRestAPI_DLL.DB;
using HSRestAPI_DLL.Entities;
using HSRestAPI_DLL.Interfaces;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace HSRestAPI_DLL.Repositories
{
    public class HairdresserRepository : IRepository<Hairdresser>
    //TODO
    {
        private HairstudioDBContext db;
        /// <summary>
        /// Method where the HairstudioDBContext used by this repository is set.
        /// </summary>
        /// <param name="ctx"></param>
        public void SetContext(HairstudioDBContext ctx)
        {
            db = ctx;
        }
        /// <summary>
        /// Constructor where a new DBContext is created
        /// </summary>
        public HairdresserRepository()
        {
            db = new HairstudioDBContext();
        }
        public IList<Hairdresser> GetAll()
        {
            using (db)
            {
                return db.Hairdressers
                    .Include(h => h.Appointments.Select(c => c.TimeRange))
                    .Include(h => h.Appointments.Select(c => c.Customer))
                    .Include(h => h.WorkingDays)
                    .ToList();
            }
        }

        public Hairdresser Get(int id)
        {
            using (db)
            {
                var hairdresser = db.Hairdressers
                    .Include(h => h.Appointments.Select(c => c.TimeRange))
                    .Include(h => h.Appointments.Select(c => c.Customer))
                    .Include(h => h.WorkingDays)
                    .FirstOrDefault(x => x.ID == id);
                return hairdresser;
            }
        }

        public bool Remove(Hairdresser t)
        {
            using (db)
            {
                db.Entry(db.Hairdressers.FirstOrDefault(x => x.ID == t.ID)).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
                return db.Hairdressers.FirstOrDefault(x => x.ID == t.ID) == null;
            }
        }

        public Hairdresser Update(Hairdresser t)
        {//TODO
            using (db)
            {
                var eh = db.Hairdressers
                    .Include(h => h.Appointments)
                    .Include(h => h.WorkingDays)
                    .FirstOrDefault(x => x.ID == t.ID);

                if (eh != null)
                {
                    //eh = Existing hairdresser
                    eh.Name = t.Name;
                    eh.Email = t.Email;
                    eh.Appointments = new List<Appointment>();
                    if (t.Appointments != null)
                    {
                        foreach (var a in t.Appointments)
                        {
                            eh.Appointments.Add(a);
                        }
                    }
                    eh.WorkingDays = new List<TimeRange>();
                    if (t.WorkingDays != null)
                    {
                        foreach (var w in t.WorkingDays)
                        {
                            eh.WorkingDays.Add(w);
                        }
                    }
                    //Password, usertype and ID are not to be changed here.
                    eh.PhoneNumber = t.PhoneNumber;
                    eh.Email = t.Email;
                    eh.Username = t.Username;
                    eh.Name = t.Name;

                    if (t.Appointments != null)
                        foreach (var a in t.Appointments)
                        {
                            eh.Appointments.Add(db.Appointments.FirstOrDefault(x => x.ID == a.ID));
                        }
                }

                db.SaveChanges();

                return eh;
            }
        }

        public Hairdresser Create(Hairdresser t)
        {
            using (db)
            {

                db.Hairdressers.Add(t);
                db.SaveChanges();
                return t;
            }
        }
    }
}
