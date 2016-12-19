using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HSRestAPI_DLL.DB;
using HSRestAPI_DLL.Entities;
using HSRestAPI_DLL.Interfaces;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;

namespace HSRestAPI_DLL.Repositories
{//TODO
    class AppointmentRepository : IRepository<Appointment>
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
        public AppointmentRepository()
        {
            db = new HairstudioDBContext();
        }
        public Appointment Create(Appointment t)
        {
            using (db = new HairstudioDBContext())
            {
                var hairdresser = db.Hairdressers.FirstOrDefault(x => x.ID == t.Hairdresser.ID);
                var customer = db.Customers.FirstOrDefault(x => x.ID == t.Customer.ID);                
                t.Hairdresser = hairdresser;
                t.Customer = customer;
                db.Appointments.Add(t);
                db.SaveChanges();
                return t;
            }
        }

        public Appointment Get(int id)
        {
            using (db = new HairstudioDBContext())
            {
                return db.Appointments
                    .Include(t => t.TimeRange)
                    .Include(t => t.Hairdresser)
                    .Include(t => t.Customer)
                    .FirstOrDefault(x => x.ID == id);
            }
        }

        public IList<Appointment> GetAll()
        {
            using (db = new HairstudioDBContext())
            {
                return db.Appointments
                    .Include(t => t.TimeRange)
                    .Include(t => t.Hairdresser)
                    .Include(t => t.Customer)
                    .ToList();
            }
        }

        public bool Remove(Appointment t)
        {
            using (db = new HairstudioDBContext())
            {
                db.Entry(t).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
                return true;
            }
        }

        public Appointment Update(Appointment t)
        {//TODO
            using (db = new HairstudioDBContext())
            {
                var ea = db.Appointments //ea = existing appointment
                    .Include(a => a.Hairdresser)
                    .Include(a => a.Customer)
                    .Include(a => a.TimeRange)
                    .FirstOrDefault(x => x.ID == t.ID);
                var hairdresser = db.Hairdressers.FirstOrDefault(x => x.ID == t.Hairdresser.ID);
                var customer = db.Customers.FirstOrDefault(x => x.ID == t.Customer.ID);
                if (ea != null)
                {
                    ea.Hairdresser = hairdresser;
                    ea.Customer = customer;
                    ea.TimeRange.TheDate = t.TimeRange.TheDate;
                    ea.TimeRange.EndTime = t.TimeRange.EndTime;
                    ea.TimeRange.StartTime = t.TimeRange.StartTime;
                }
                //var objectStateManager = ((IObjectContextAdapter)db).ObjectContext.ObjectStateManager;
                //objectStateManager.ChangeObjectState(ea, EntityState.Modified);
                db.SaveChanges();
                return t;
            }
        }
    }
}
