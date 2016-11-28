using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSRestAPI_DLL.DB
{
    class HairstudioDBInitializer : CreateDatabaseIfNotExists<HairstudioDBContext>
    {
        protected override void Seed(HairstudioDBContext db)
        {
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

