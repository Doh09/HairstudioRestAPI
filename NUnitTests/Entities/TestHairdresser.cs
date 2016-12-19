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
    public class TestHairdresser
    {
        [Test]
        public void TestProperties()
        {
            /*Hairdresser : User //ID and other variables inherited are tested in User.
            - Working hours
            - Appointments
             */
            Hairdresser hairdresser = new Hairdresser();
            //OtheC:\Users\Alex\Documents\GitHub\HairstudioRestAPI\HSRestAPIMVC\packages.configr entities are tested further in their own test class
            //Appointments
            Appointment appointment1 = new Appointment();
            appointment1.ID = 1;
            Appointment appointment2 = new Appointment();
            appointment2.ID = 2;

            Assert.IsNotNull(hairdresser.Appointments);
            hairdresser.Appointments.Add(appointment1);
            hairdresser.Appointments.Add(appointment2);
            Assert.AreEqual(hairdresser.Appointments.Count, 2);

            //TimeRanges
            TimeRange timeRange1 = new TimeRange();
            timeRange1.ID = 1;
            TimeRange timeRange2 = new TimeRange();
            timeRange1.ID = 2;

            Assert.IsNotNull(hairdresser.WorkingDays);
            hairdresser.WorkingDays.Add(timeRange1);
            hairdresser.WorkingDays.Add(timeRange2);
            Assert.AreEqual(hairdresser.WorkingDays.Count, 2);
        }
    }
}
