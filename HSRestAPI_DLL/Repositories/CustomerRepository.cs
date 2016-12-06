using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HSRestAPI_DLL.DB;
using HSRestAPI_DLL.Entities;
using HSRestAPI_DLL.Interfaces;

namespace HSRestAPI_DLL.Repositories
{//TODO
    class CustomerRepository : IRepository<Customer>
    {
        public List<Customer> GetAll()
        {
            using (var db = new HairstudioDBContext())
            {
                return db.Customers
                    .Include(h => h.Appointments.Select(c => c.TimeRange))
                    .Include(h => h.Appointments.Select(c => c.Hairdresser))
                    .Include(h => h.Appointments)
                    //.Include(h => h.Appointments.Select(c => c.Customer))
                    .ToList();
            }
        }

        public Customer Get(int id)
        {
            using (var db = new HairstudioDBContext())
            {
                return db.Customers
                    .Include(h => h.Appointments.Select(c => c.TimeRange))
                    .Include(h => h.Appointments.Select(c => c.Hairdresser))
                    .FirstOrDefault(x => x.ID == id);
            }
        }

        public bool Remove(Customer t)
        {
            using (var db = new HairstudioDBContext())
            {
                db.Entry(db.Customers.FirstOrDefault(x => x.ID == t.ID)).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
                return db.Customers.FirstOrDefault(x => x.ID == t.ID) == null;
            }
        }

        public Customer Update(Customer t)
        {
            using (var db = new HairstudioDBContext())
            {
                db.Entry(t).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return t;
            }
        }

        public Customer Create(Customer t)
        {
            using (var db = new HairstudioDBContext())
            {
                db.Customers.Add(t);
                db.SaveChanges();
                return t;
            }
        }
    }
}
