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
            //Configuration.ProxyCreationEnabled = false;
            Database.SetInitializer(new HairstudioDBInitializer());
        }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Hairdresser> Hairdressers { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<ServiceOffered> ServicesOffered { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<TimeRange> TimeRanges { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>()
                .HasRequired(m => m.Hairdresser)
                .WithMany(t => t.Appointments)
                        //.HasForeignKey(m => m.Hairdresser.ID)
                        .WillCascadeOnDelete(false)
                        ;

            modelBuilder.Entity<Appointment>()
                .HasRequired(m => m.Customer)
                .WithMany(t => t.Appointments)
                        //.HasForeignKey(m => m.Customer.ID)
                        .WillCascadeOnDelete(false)
                        ;

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
