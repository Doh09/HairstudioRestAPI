using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HSRestAPI_DLL.Entities;

namespace HSRestAPI_DLL.DB
{
    public class HairstudioDBContext : DbContext
    {
        public HairstudioDBContext() : base("Hairstudio")
        {
            Configuration.ProxyCreationEnabled = false;
            Database.SetInitializer(new HairstudioDBInitializer());
        }

        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Hairdresser> Hairdressers { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<ServiceOffered> ServicesOffered { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<WorkingDay> WorkingDays { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Movie>()
            //    .HasMany(t => t.Genres)
            //    .WithMany(t => t.Movies)
            //    .Map(t => t.MapLeftKey("MovieID").MapRightKey("GenreID").ToTable("MovieGenre"));

            //modelBuilder.Entity<Order>().HasMany(x => x.Movies).WithMany();
            base.OnModelCreating(modelBuilder);
        }
    }
}
