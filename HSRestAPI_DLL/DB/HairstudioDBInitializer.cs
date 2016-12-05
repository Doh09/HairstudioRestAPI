using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HSRestAPI_DLL.Entities;

namespace HSRestAPI_DLL.DB
{
    class HairstudioDBInitializer : CreateDatabaseIfNotExists<HairstudioDBContext>
    {
        protected override void Seed(HairstudioDBContext db)
        {
            var hairdresser = new Hairdresser();
            hairdresser.ID = 0;
            hairdresser.Appointments = new List<Appointment>();
            hairdresser.WorkingDays = new List<TimeRange>();
            hairdresser.Email = "HDEmail@gmail.com";
            hairdresser.Name = "Rita Jørgensen";
            hairdresser.Password = "LeStronkPW";
            hairdresser.PhoneNumber = 88888888;
            hairdresser.UserType = "hairdresser";
            hairdresser.Username = "HDusername";
            
            var customer = new Customer();
            customer.ID = 0;
            customer.Appointments = new List<Appointment>();
            customer.Email = "CEmail@gmail.com";
            customer.Name = "Roland Ripoff";
            customer.Password = "LeWeakassPW";
            customer.PhoneNumber = 11111111;
            customer.UserType = "customer";
            customer.Username = "CUsername";

            db.Hairdressers.Add(hairdresser);
            db.Customers.Add(customer);
            //var genre1 = new Genre() { ID = 1, Name = "Adventure" };
            //db.Genres.Add(genre1);
            //db.Movies.Add(new Movie()
            //{
            //    ID = 1,
            //    Title = "Room",
            //    Year = 2015,
            //    Price = 120.00,
            //    ImageURL = "https://images-na.ssl-images-amazon.com/images/M/MV5BMjE4NzgzNzEwMl5BMl5BanBnXkFtZTgwMTMzMDE0NjE@._V1_UX182_CR0,0,182,268_AL_.jpg",
            //    TrailerURL = "https://www.youtube.com/embed/PPZqF_TPTGs",
            //    Genres = new List<Genre> { genre1 }
            //});

            base.Seed(db);
        }
    }
}

