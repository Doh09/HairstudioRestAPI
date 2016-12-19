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
    class ServiceOfferedRepository : IRepository<ServiceOffered>
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
        public ServiceOfferedRepository()
        {
            db = new HairstudioDBContext();
        }
        public ServiceOffered Create(ServiceOffered t)
        {
            using (db)
            {
                db.ServicesOffered.Add(t);
                db.SaveChanges();
                return t;
            }
        }

        public ServiceOffered Get(int id)
        {
            using (db)
            {
                return db.ServicesOffered.FirstOrDefault(x => x.ID == id);
            }
        }

        public IList<ServiceOffered> GetAll()
        {
            using (db)
            {
                return db.ServicesOffered.ToList();
            }
        }

        public bool Remove(ServiceOffered t)
        {
            using (db)
            {
                db.Entry(t).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
                return true;
            }
        }

        public ServiceOffered Update(ServiceOffered t)
        {//TODO
            using (db)
            {
                db.Entry(t).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return t;
            }
        }
    }
}
