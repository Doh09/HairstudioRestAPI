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
            /*Customer : User //ID and other inherited variables are tested in User.
            - Appointments
             */

            Customer customer = new Customer();
            customer.Appointments = new List<Appointment>();
            //Appointment is tested further in its own test class
            Appointment appointment1 = new Appointment();
            appointment1.ID = 1;
            Appointment appointment2 = new Appointment();
            appointment2.ID = 2;

            Assert.IsNotNull(customer.Appointments);
            customer.Appointments.Add(appointment1);
            customer.Appointments.Add(appointment2);
            Assert.AreEqual(customer.Appointments.Count, 2);
        }
    }
}
