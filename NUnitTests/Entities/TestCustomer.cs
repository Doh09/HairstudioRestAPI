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
            appointment1.TimeRange.StartTime = DateTime.Now;
            appointment1.TimeRange.EndTime = appointment1.TimeRange.StartTime; //Fix
            appointment1.TimeRange.EndTime.AddMinutes(30);
            appointment1.Hairdresser = new Hairdresser();
            appointment1.Customer = new Customer();

            Appointment appointment2 = new Appointment();
            appointment2.ID = 1;
            appointment2.TimeRange.StartTime = DateTime.Now;
            appointment2.TimeRange.StartTime.AddMinutes(30);
            appointment2.TimeRange.EndTime = appointment2.TimeRange.StartTime; //Fix
            appointment2.TimeRange.EndTime.AddMinutes(30);
            appointment2.Hairdresser = new Hairdresser();
            appointment2.Customer = new Customer();

            //Test if appointments can be addded and retrieved correctly.
            customer.AddAppointment(appointment1);
            customer.AddAppointment(appointment2);
            Assert.AreSame(appointment1, customer.GetAppointment(appointment1.TimeRange.GetDate()));
            Assert.AreSame(appointment2, customer.GetAppointment(appointment2.TimeRange.GetDate()));
            //List of appointments for the given day.
        }
    }
}
