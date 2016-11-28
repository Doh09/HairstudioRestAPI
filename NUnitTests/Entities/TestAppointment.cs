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
            appointment.StartTime = DateTime.Now;
            appointment.EndTime = appointment.StartTime; //Fix
            appointment.EndTime.AddMinutes(30);
            appointment.HairdresserID = 1;
            appointment.CustomerID = 2;

            Assert.AreEqual(appointment.ID, -1);
            Assert.AreEqual(appointment.StartTime.Date, DateTime.Now.Date);
            Assert.AreEqual(appointment.EndTime.Date, DateTime.Now.Date);
            Assert.AreEqual(appointment.HairdresserID, 1);
            Assert.AreEqual(appointment.CustomerID, 2);
        }
    }
}
