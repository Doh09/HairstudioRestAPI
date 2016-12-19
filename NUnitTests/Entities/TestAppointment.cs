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
    public class TestAppointment
    {
        [Test]
        public void TestProperties()
        {
            /*Appointment : IEntity
            - ID
            - TimeRange
            - Hairdresser
            - Customer
             */
            Appointment appointment = new Appointment();
            appointment.ID = 1;
            appointment.TimeRange = new TimeRange();
            appointment.Hairdresser = new Hairdresser();
            appointment.Customer = new Customer();
            
            Assert.AreEqual(appointment.ID, 1);
            //Entity variables are tested more in their own test classes.
            Assert.IsNotNull(appointment.TimeRange);
            Assert.IsNotNull(appointment.Hairdresser);
            Assert.IsNotNull(appointment.Customer);
        }
    }
}
