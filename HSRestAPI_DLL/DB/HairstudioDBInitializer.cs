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

            //Hairdressers
            var hairdresser = new Hairdresser();
            hairdresser.ID = 0;
            hairdresser.Appointments = new List<Appointment>();
            hairdresser.WorkingDays = new List<TimeRange>();
            hairdresser.Email = "HDEmail@gmail.com";
            hairdresser.Name = "Rita Jørgensen";
            hairdresser.Password = "StrongPassword";
            hairdresser.PhoneNumber = 88888888;
            hairdresser.UserType = "hairdresser";
            hairdresser.Username = "HDusername";

            db.Hairdressers.Add(hairdresser);

            //Customers
            var customer = new Customer();
            customer.ID = 0;
            customer.Appointments = new List<Appointment>();
            customer.Email = "CEmail@gmail.com";
            customer.Name = "Roland Dakostumer";
            customer.Password = "RolandsPassword";
            customer.PhoneNumber = 11111111;
            customer.UserType = "customer";
            customer.Username = "CUsername";

            db.Customers.Add(customer);

            //Services offered
            var serviceOffered1 = new ServiceOffered();
            serviceOffered1.ID = 0;
            serviceOffered1.Message = "Dameklip";
            serviceOffered1.Price = 345;
            var serviceOffered2 = new ServiceOffered();
            serviceOffered2.ID = 0;
            serviceOffered2.Message = "Herreklip";
            serviceOffered2.Price = 270;
            var serviceOffered3 = new ServiceOffered();
            serviceOffered3.ID = 0;
            serviceOffered3.Message = "Børneklip";
            serviceOffered3.Price = 230;
            var serviceOffered4 = new ServiceOffered();
            serviceOffered4.ID = 0;
            serviceOffered4.Message = "Maskinklip";
            serviceOffered4.Price = 100;
            var serviceOffered5 = new ServiceOffered();
            serviceOffered5.ID = 0;
            serviceOffered5.Message = "Farvning af hår";
            serviceOffered5.Price = 700;

            db.ServicesOffered.Add(serviceOffered1);
            db.ServicesOffered.Add(serviceOffered2);
            db.ServicesOffered.Add(serviceOffered3);
            db.ServicesOffered.Add(serviceOffered4);
            db.ServicesOffered.Add(serviceOffered5);

            //Messages
            var welcome = new Message();
            welcome.ID = 1;
            welcome.AreaMessageIsUsed = "welcome";
            welcome.Description = "Velkommen til vores frisørsalon!";

            var monday = new Message();
            monday.ID = 100;
            monday.AreaMessageIsUsed = "openinghours_monday";
            monday.Description = "8-17";

            var tuesday = new Message();
            tuesday.ID = 101;
            tuesday.AreaMessageIsUsed = "openinghours_tuesday";
            tuesday.Description = "8-17";

            var wednesday = new Message();
            wednesday.ID = 102;
            wednesday.AreaMessageIsUsed = "openinghours_wednesday";
            wednesday.Description = "8-17";

            var thursday = new Message();
            thursday.ID = 103;
            thursday.AreaMessageIsUsed = "openinghours_thursday";
            thursday.Description = "8-17";

            var friday = new Message();
            friday.ID = 104;
            friday.AreaMessageIsUsed = "openinghours_friday";
            friday.Description = "8-17";

            var saturday = new Message();
            saturday.ID = 105;
            saturday.AreaMessageIsUsed = "openinghours_saturday";
            saturday.Description = "Kun efter aftale";

            var sunday = new Message();
            sunday.ID = 106;
            sunday.AreaMessageIsUsed = "openinghours_sunday";
            sunday.Description = "Kun efter aftale";

            var contact = new Message();
            contact.ID = 107;
            contact.AreaMessageIsUsed = "contact";
            contact.Description = "Vi kan kontaktes per telefon på 1234 5678";

            var navbarlogo = new Message();
            navbarlogo.ID = 108;
            navbarlogo.AreaMessageIsUsed = "navbar_logo";
            navbarlogo.Description = "http://i.imgur.com/hWWNTcs.jpg";

            var fblogo = new Message();
            fblogo.ID = 109;
            fblogo.AreaMessageIsUsed = "fb_logo";
            fblogo.Description = "http://i.imgur.com/arVz7P6.png";

            var fblink = new Message();
            fblink.ID = 110;
            fblink.AreaMessageIsUsed = "fb_link";
            fblink.Description = "https://www.facebook.com/";

            var pricelistmsg = new Message();
            pricelistmsg.ID = 113;
            pricelistmsg.AreaMessageIsUsed = "pricelist_msg";
            pricelistmsg.Description = "Alle priser er i danske kroner";

            var imgcar1 = new Message();
            imgcar1.ID = 111;
            imgcar1.AreaMessageIsUsed = "imgcarousel";
            imgcar1.Description = "http://i.imgur.com/ipFeu7R.png";

            var imgcar2 = new Message();
            imgcar2.ID = 112;
            imgcar2.AreaMessageIsUsed = "imgcarousel";
            imgcar2.Description = "http://i.imgur.com/KUJauPn.png";

            db.Messages.Add(welcome);
            db.Messages.Add(monday);
            db.Messages.Add(tuesday);
            db.Messages.Add(wednesday);
            db.Messages.Add(thursday);
            db.Messages.Add(friday);
            db.Messages.Add(saturday);
            db.Messages.Add(sunday);
            db.Messages.Add(contact);
            db.Messages.Add(navbarlogo);
            db.Messages.Add(fblogo);
            db.Messages.Add(fblink);
            db.Messages.Add(pricelistmsg);
            db.Messages.Add(imgcar1);
            db.Messages.Add(imgcar2);

            base.Seed(db);
        }
    }
}

