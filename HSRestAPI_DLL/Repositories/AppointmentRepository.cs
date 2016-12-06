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
        public Appointment Create(Appointment t)
        {
            using (var ctx = new HairstudioDBContext())
            {
                var hairdresser = ctx.Hairdressers.FirstOrDefault(x => x.ID == t.Hairdresser.ID);
                var customer = ctx.Customers.FirstOrDefault(x => x.ID == t.Customer.ID);
                
                t.Hairdresser = hairdresser;
                t.Customer = customer;
                ctx.Appointments.Add(t);
                ctx.SaveChanges();
                return t;
            }
        }

        public Appointment Get(int id)
        {
            using (var ctx = new HairstudioDBContext())
            {
                return ctx.Appointments
                    .Include(t => t.TimeRange)
                    .Include(t => t.Hairdresser)
                    .Include(t => t.Customer)
                    .FirstOrDefault(x => x.ID == id);
            }
        }

        public List<Appointment> GetAll()
        {
            using (var ctx = new HairstudioDBContext())
            {
                return ctx.Appointments
                    .Include(t => t.TimeRange)
                    .Include(t => t.Hairdresser)
                    .Include(t => t.Customer)
                    .ToList();
            }
        }

        public bool Remove(Appointment t)
        {
            using (var ctx = new HairstudioDBContext())
            {
                ctx.Entry(t).State = System.Data.Entity.EntityState.Deleted;
                ctx.SaveChanges();
                return true;
            }
        }

        public Appointment Update(Appointment t)
        {//TODO
            using (var ctx = new HairstudioDBContext())
            {
                var ea = ctx.Appointments //ea = existing appointment
                    .Include(a => a.Hairdresser)
                    .Include(a => a.Customer)
                    .Include(a => a.TimeRange)
                    .FirstOrDefault(x => x.ID == t.ID);

                EntityUpdater.UpdateAppointment(ea, t);
                var objectStateManager = ((IObjectContextAdapter)ctx).ObjectContext.ObjectStateManager;
                objectStateManager.ChangeObjectState(ea, EntityState.Modified);
                //ea.TimeRange.TheDate = t.TimeRange.TheDate; //<--- Works, with only a.TimeRange included.
                //ea.Hairdresser = t.Hairdresser; //check if new hairdresser/customer is made, 
                //or system is intelligent and knows from ID not to create more tables.
                ctx.SaveChanges();
                return t;
            }
        }
    }
}
