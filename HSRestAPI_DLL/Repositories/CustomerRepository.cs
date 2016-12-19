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
        public CustomerRepository()
        {
            db = new HairstudioDBContext();
        }
        public IList<Customer> GetAll()
        {
            using (db)
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
            using (db)
            {
                return db.Customers
                    .Include(h => h.Appointments.Select(c => c.TimeRange))
                    .Include(h => h.Appointments.Select(c => c.Hairdresser))
                    .Include(h => h.Appointments)
                    .FirstOrDefault(x => x.ID == id);
            }
        }

        public bool Remove(Customer t)
        {
            using (db)
            {
                db.Entry(db.Customers.FirstOrDefault(x => x.ID == t.ID)).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
                return db.Customers.FirstOrDefault(x => x.ID == t.ID) == null;
            }
        }

        public Customer Update(Customer t)
        {
            using (db)
            {
                db.Entry(t).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return t;
            }
        }

        public Customer Create(Customer t)
        {
            using (db)
            {
                db.Customers.Add(t);
                db.SaveChanges();
                return t;
            }
        }
    }
}
