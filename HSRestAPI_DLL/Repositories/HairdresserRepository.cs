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
        public List<Hairdresser> GetAll()
        {
            using (var db = new HairstudioDBContext())
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
            using (var db = new HairstudioDBContext())
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
            using (var db = new HairstudioDBContext())
            {
                db.Entry(db.Hairdressers.FirstOrDefault(x => x.ID == t.ID)).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
                return db.Hairdressers.FirstOrDefault(x => x.ID == t.ID) == null;
            }
        }

        public Hairdresser Update(Hairdresser t)
        {//TODO
            using (var db = new HairstudioDBContext())
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
                    foreach (var a in t.Appointments)
                    {
                        eh.Appointments.Add(a);
                    }
                    eh.WorkingDays = new List<TimeRange>();
                    foreach (var w in t.WorkingDays)
                    {
                        eh.WorkingDays.Add(w);
                    }
                    eh.Password = t.Password;
                    eh.UserType = t.UserType;
                    eh.PhoneNumber = t.PhoneNumber;
                    eh.Username = t.Username;

                    if (t.Appointments != null)
                        foreach (var a in t.Appointments)
                        {
                            eh.Appointments.Add(db.Appointments.FirstOrDefault(x => x.ID == a.ID));
                        }
                }
     
                //db.Entry(existingHairdresser).State = EntityState.Modified;

                //foreach (var a in existingHairdresser.Appointments)
                //{
                //    db.Entry(a).State = EntityState.Modified;
                //}
                //foreach (var w in existingHairdresser.WorkingDays)
                //{
                //    db.Entry(w).State = EntityState.Modified;
                //}

                db.SaveChanges();

                return eh;
            }
        }

        public Hairdresser Create(Hairdresser t)
        {
            using (var db = new HairstudioDBContext())
            {

                db.Hairdressers.Add(t);
                db.SaveChanges();
                return t;
            }
        }
    }
}
