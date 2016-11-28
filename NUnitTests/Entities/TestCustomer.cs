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
            customer.Appointments = new Dictionary<DateTime, Appointment>();
            Appointment appointment1 = new Appointment();
            appointment1.ID = -1;
            appointment1.StartTime = DateTime.Now;
            appointment1.EndTime = appointment1.StartTime; //Fix
            appointment1.EndTime.AddMinutes(30);
            appointment1.HairdresserID = 1;
            appointment1.CustomerID = 2;

            Appointment appointment2 = new Appointment();
            appointment2.ID = -2;
            appointment2.StartTime = DateTime.Now;
            appointment2.EndTime = appointment2.StartTime; //Fix
            appointment2.EndTime.AddMinutes(30);
            appointment2.HairdresserID = 1;
            appointment2.CustomerID = 3;

            //Test if appointments can be addded and retrieved correctly.
            customer.Appointments.Add(appointment1.StartTime, appointment1);
            customer.Appointments.Add(appointment2.StartTime, appointment2);
            Assert.AreSame(appointment1, customer.Appointments[appointment1.StartTime]);
            Assert.AreSame(appointment2, customer.Appointments[appointment2.StartTime]);
            //List of appointments for the given day.
        }
    }
}
