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
        public MessageRepository()
        {
                db = new HairstudioDBContext();
        }

        public Message Create(Message t)
        {
            using (db = new HairstudioDBContext())
            {
                db.Messages.Add(t);
                db.SaveChanges();
                return t;
            }
        }

        public Message Get(int id)
        {
            using (db = new HairstudioDBContext())
            {
                return db.Messages.FirstOrDefault(x => x.ID == id);
            }
        }

        public IList<Message> GetAll()
        {
            using (db = new HairstudioDBContext())
            {
                return db.Messages.ToList();
            }
        }

        public bool Remove(Message t)
        {
            using (db = new HairstudioDBContext())
            {
                db.Entry(t).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
                return true;
            }
        }

        public Message Update(Message t)
        {//TODO
            using (db = new HairstudioDBContext())
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
