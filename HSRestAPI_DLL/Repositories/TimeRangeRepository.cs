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
            using (var ctx = new HairstudioDBContext())
            {
                ctx.TimeRanges.Add(t);
                ctx.SaveChanges();
                return t;
            }
        }

        public TimeRange Get(int id)
        {
            using (var ctx = new HairstudioDBContext())
            {
                return ctx.TimeRanges.FirstOrDefault(x => x.ID == id);
            }
        }

        public List<TimeRange> GetAll()
        {
            using (var ctx = new HairstudioDBContext())
            {
                return ctx.TimeRanges.ToList();
            }
        }

        public bool Remove(TimeRange t)
        {
            using (var ctx = new HairstudioDBContext())
            {
                ctx.Entry(t).State = System.Data.Entity.EntityState.Deleted;
                ctx.SaveChanges();
                return true;
            }
        }

        public TimeRange Update(TimeRange t)
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
