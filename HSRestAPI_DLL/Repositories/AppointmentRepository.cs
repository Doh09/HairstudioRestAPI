using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HSRestAPI_DLL.DB;
using HSRestAPI_DLL.Entities;
using HSRestAPI_DLL.Interfaces;

namespace HSRestAPI_DLL.Repositories
{//TODO
    class AppointmentRepository : IRepository<Appointment>
    {
        public Appointment Create(Appointment t)
        {
            using (var ctx = new HairstudioDBContext())
            {
                ctx.Appointments.Add(t);
                ctx.SaveChanges();
                return t;
            }
        }

        public Appointment Get(int id)
        {
            using (var ctx = new HairstudioDBContext())
            {
                return ctx.Appointments.FirstOrDefault(x => x.ID == id);
            }
        }

        public List<Appointment> GetAll()
        {
            using (var ctx = new HairstudioDBContext())
            {
                return ctx.Appointments.ToList();
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
                ctx.Entry(t).State = System.Data.Entity.EntityState.Modified;
                ctx.SaveChanges();
                return t;
            }
        }
    }
}
