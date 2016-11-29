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
            /*Appointment : AbstractEntity
            - Appointment start time
            - Appointment end time
            - HairdresserID
            - CustomerID
             */
            Appointment appointment = new Appointment();
            appointment.ID = -1;
            appointment.TimeAndDate.StartTime = DateTime.Now;
            appointment.TimeAndDate.EndTime = appointment.TimeAndDate.StartTime; //Fix
            appointment.TimeAndDate.EndTime.AddMinutes(30);
            appointment.Hairdresser = new Hairdresser();
            appointment.Customer = new Customer();

            Assert.AreEqual(appointment.ID, -1);
            Assert.AreEqual(appointment.TimeAndDate.StartTime.Date, DateTime.Now.Date);
            Assert.AreEqual(appointment.TimeAndDate.EndTime.Date, DateTime.Now.Date);
            Assert.IsNotNull(appointment.Hairdresser);
            Assert.IsNotNull(appointment.Customer);
        }
    }
}
