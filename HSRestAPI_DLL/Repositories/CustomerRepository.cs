using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HSRestAPI_DLL.Entities;
using HSRestAPI_DLL.Interfaces;

namespace HSRestAPI_DLL.Repositories
{//TODO
    class CustomerRepository : IRepository<Customer>
    {
        public List<Customer> GetAll()
        {
            throw new NotImplementedException();
        }

        public Customer Get(int id)
        {
            throw new NotImplementedException();
        }

        public Customer Get(string email)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Customer t)
        {
            throw new NotImplementedException();
        }

        public Customer Update(Customer t)
        {
            throw new NotImplementedException();
        }

        public Customer Create(Customer t)
        {
            throw new NotImplementedException();
        }
    }
}
