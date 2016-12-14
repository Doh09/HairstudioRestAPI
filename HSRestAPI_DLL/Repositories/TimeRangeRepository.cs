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
    class TimeRangeRepository : IRepository<TimeRange>
    {
        public TimeRange Create(TimeRange t)
        {
            using (var db = new HairstudioDBContext())
            {
                db.TimeRanges.Add(t);
                db.SaveChanges();
                return t;
            }
        }

        public TimeRange Get(int id)
        {
            using (var db = new HairstudioDBContext())
            {
                return db.TimeRanges.FirstOrDefault(x => x.ID == id);
            }
        }

        public List<TimeRange> GetAll()
        {
            using (var db = new HairstudioDBContext())
            {
                return db.TimeRanges.ToList();
            }
        }

        public bool Remove(TimeRange t)
        {
            using (var db = new HairstudioDBContext())
            {
                db.Entry(t).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
                return true;
            }
        }

        public TimeRange Update(TimeRange t)
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
