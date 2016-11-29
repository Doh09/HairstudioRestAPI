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
        public virtual DbSet<TimeRange> TimeRanges { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //http://stackoverflow.com/questions/9613421/map-a-dictionary-in-entity-framework-code-first-approach
            //one-to-many 
            //modelBuilder.Entity<Appointment>()
            //    //.HasRequired<Customer>(a => a.Customer).WithMany(c => c.GetAllAppointments().Values)
            //            .HasRequired<Hairdresser>(s => s.Hairdresser) // Student entity requires Standard 
            //            .WithMany(s => s.Appointments.Values); // Standard entity includes many Students entities
            ////modelBuilder.Entity<Order>().HasMany(x => x.Movies).WithMany();
            base.OnModelCreating(modelBuilder);
        }
    }
}
