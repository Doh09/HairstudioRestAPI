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
{ //TODO

    class MessageRepository : IRepository<Message>
    {
        public Message Create(Message t)
        {
            using (var db = new HairstudioDBContext())
            {
                db.Messages.Add(t);
                db.SaveChanges();
                return t;
            }
        }

        public Message Get(int id)
        {
            using (var db = new HairstudioDBContext())
            {
                return db.Messages.FirstOrDefault(x => x.ID == id);
            }
        }

        public List<Message> GetAll()
        {
            using (var db = new HairstudioDBContext())
            {
                return db.Messages.ToList();
            }
        }

        public bool Remove(Message t)
        {
            using (var db = new HairstudioDBContext())
            {
                db.Entry(t).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
                return true;
            }
        }

        public Message Update(Message t)
        {//TODO
            using (var db = new HairstudioDBContext())
            {
                var em = db.Messages.FirstOrDefault(x => x.ID == t.ID);
                if (em != null)
                {
                    em.Description = t.Description;
                    db.SaveChanges();
                }
                return em;
            }
        }
    }
}
