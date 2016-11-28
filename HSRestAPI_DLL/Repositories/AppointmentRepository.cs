using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HSRestAPI_DLL.Entities;
using HSRestAPI_DLL.Interfaces;

namespace HSRestAPI_DLL.Repositories
{//TODO
    class AppointmentRepository : IRepository<Appointment>
    {
        public List<Appointment> GetAll()
        {
            throw new NotImplementedException();
        }

        public Appointment Get(int id)
        {
            throw new NotImplementedException();
        }

        public Appointment Get(string email)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Appointment t)
        {
            throw new NotImplementedException();
        }

        public Appointment Update(Appointment t)
        {
            throw new NotImplementedException();
        }

        public Appointment Create(Appointment t)
        {
            throw new NotImplementedException();
        }
    }
}
