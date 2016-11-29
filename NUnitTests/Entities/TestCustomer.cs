using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HSRestAPI_DLL.Entities;
using NUnit.Framework;

namespace NUnitTests.Entities
{
    [TestFixture]
    public class TestCustomer
    {
        [Test]
        public void TestProperties()
        {
            /*Customer : User //ID and other variables inherited are tested in User.
            - Appointments
             */
            Customer customer = new Customer();
            Appointment appointment1 = new Appointment();
            appointment1.ID = -1;
            appointment1.TimeAndDate.StartTime = DateTime.Now;
            appointment1.TimeAndDate.EndTime = appointment1.TimeAndDate.StartTime; //Fix
            appointment1.TimeAndDate.EndTime.AddMinutes(30);
            appointment1.Hairdresser = new Hairdresser();
            appointment1.Customer = new Customer();

            Appointment appointment2 = new Appointment();
            appointment2.ID = 1;
            appointment2.TimeAndDate.StartTime = DateTime.Now;
            appointment2.TimeAndDate.StartTime.AddMinutes(30);
            appointment2.TimeAndDate.EndTime = appointment2.TimeAndDate.StartTime; //Fix
            appointment2.TimeAndDate.EndTime.AddMinutes(30);
            appointment2.Hairdresser = new Hairdresser();
            appointment2.Customer = new Customer();

            //Test if appointments can be addded and retrieved correctly.
            customer.SetAppointment(appointment1);
            customer.SetAppointment(appointment2);
            Assert.AreSame(appointment1, customer.GetAppointment(appointment1.TimeAndDate.GetDate()));
            Assert.AreSame(appointment2, customer.GetAppointment(appointment2.TimeAndDate.GetDate()));
            //List of appointments for the given day.
        }
    }
}
