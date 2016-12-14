using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HSRestAPI_DLL.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HSRestAPI_DLL.DB
{
    public class HairstudioDBContext : DbContext
    {
        public HairstudioDBContext() : base("Hairstudio")
        {
            Configuration.ProxyCreationEnabled = false;
            Database.SetInitializer(new HairstudioDBInitializer());
        }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Hairdresser> Hairdressers { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<ServiceOffered> ServicesOffered { get; set; }
        //public DbSet<User> Users { get; set; }
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
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
