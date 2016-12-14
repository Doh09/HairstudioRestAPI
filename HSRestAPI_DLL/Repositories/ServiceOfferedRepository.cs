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
        public ServiceOffered Create(ServiceOffered t)
        {
            using (var db = new HairstudioDBContext())
            {
                db.ServicesOffered.Add(t);
                db.SaveChanges();
                return t;
            }
        }

        public ServiceOffered Get(int id)
        {
            using (var db = new HairstudioDBContext())
            {
                return db.ServicesOffered.FirstOrDefault(x => x.ID == id);
            }
        }

        public List<ServiceOffered> GetAll()
        {
            using (var db = new HairstudioDBContext())
            {
                return db.ServicesOffered.ToList();
            }
        }

        public bool Remove(ServiceOffered t)
        {
            using (var db = new HairstudioDBContext())
            {
                db.Entry(t).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
                return true;
            }
        }

        public ServiceOffered Update(ServiceOffered t)
        {//TODO
            using (var db = new HairstudioDBContext())
            {
                db.Entry(t).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return t;
            }
        }
    }
}
