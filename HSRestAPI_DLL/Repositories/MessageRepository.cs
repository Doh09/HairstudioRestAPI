using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HSRestAPI_DLL.DB;
using HSRestAPI_DLL.Entities;
using HSRestAPI_DLL.Interfaces;

namespace HSRestAPI_DLL.Repositories
{ //TODO

    class MessageRepository : IRepository<Message>
    {
        public Message Create(Message t)
        {
            using (var ctx = new HairstudioDBContext())
            {
                ctx.Messages.Add(t);
                ctx.SaveChanges();
                return t;
            }
        }

        public Message Get(int id)
        {
            using (var ctx = new HairstudioDBContext())
            {
                return ctx.Messages.FirstOrDefault(x => x.ID == id);
            }
        }

        public List<Message> GetAll()
        {
            using (var ctx = new HairstudioDBContext())
            {
                return ctx.Messages.ToList();
            }
        }

        public bool Remove(Message t)
        {
            using (var ctx = new HairstudioDBContext())
            {
                ctx.Entry(t).State = System.Data.Entity.EntityState.Deleted;
                ctx.SaveChanges();
                return true;
            }
        }

        public Message Update(Message t)
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
