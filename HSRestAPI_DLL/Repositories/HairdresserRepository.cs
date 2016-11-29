using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HSRestAPI_DLL.DB;
using HSRestAPI_DLL.Entities;
using HSRestAPI_DLL.Interfaces;

namespace HSRestAPI_DLL.Repositories
{
    public class HairdresserRepository : IRepository<Hairdresser>
        //TODO
    {
        public List<Hairdresser> GetAll()
        {
            using (var db = new HairstudioDBContext())
            {
                return db.Hairdressers.ToList();
            }
        }

        public Hairdresser Get(int id)
        {
            using (var db = new HairstudioDBContext())
            {
                var hairdressers = db.Hairdressers.FirstOrDefault(x => x.ID == id);
                return hairdressers;
            }
        }
        public Hairdresser Get(string email)
        {
            using (var db = new HairstudioDBContext())
            {
                return db.Hairdressers.FirstOrDefault(x => x.Email == email);
            }
        }

        public bool Remove(Hairdresser t)
        {
            using (var db = new HairstudioDBContext())
            {
                db.Entry(db.Hairdressers.FirstOrDefault(x => x.ID == t.ID)).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
                return db.Hairdressers.FirstOrDefault(x => x.ID == t.ID) == null;
            }
        }

        public Hairdresser Update(Hairdresser t)
        {
            using (var db = new HairstudioDBContext())
            {
                var existingHairdresser = db.Hairdressers.FirstOrDefault(x => x.ID == t.ID);
                if (existingHairdresser != null)
                {
                    existingHairdresser.Name = t.Name;
                    existingHairdresser.Email = t.Email;
                    existingHairdresser.SetAllAppointments(t.GetAllAppointments());
                    existingHairdresser.SetAllWorkingDays(t.GetAllWorkingDays());
                    existingHairdresser.Password = t.Password;
                    existingHairdresser.UserType = t.UserType;
                    existingHairdresser.PhoneNumber = t.PhoneNumber;
                    existingHairdresser.Username = t.Username;
                }
                db.SaveChanges();
                return t;
            }
        }

        public Hairdresser Create(Hairdresser t)
        {
            using (var db = new HairstudioDBContext())
            {

                db.Hairdressers.Add(t);
                db.SaveChanges();
                return t;
            }
        }
    }
}
