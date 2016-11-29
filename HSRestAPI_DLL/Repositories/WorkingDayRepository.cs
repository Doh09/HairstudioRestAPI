using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HSRestAPI_DLL.Entities;
using HSRestAPI_DLL.Interfaces;

namespace HSRestAPI_DLL.Repositories
{//TODO
    class WorkingDayRepository : IRepository<TimeRange>
    {
        public List<TimeRange> GetAll()
        {
            throw new NotImplementedException();
        }

        public TimeRange Get(int id)
        {
            throw new NotImplementedException();
        }

        public TimeRange Get(string email)
        {
            throw new NotImplementedException();
        }

        public bool Remove(TimeRange t)
        {
            throw new NotImplementedException();
        }

        public TimeRange Update(TimeRange t)
        {
            throw new NotImplementedException();
        }

        public TimeRange Create(TimeRange t)
        {
            throw new NotImplementedException();
        }
    }
}
