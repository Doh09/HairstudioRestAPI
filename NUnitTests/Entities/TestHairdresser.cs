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
            hairdresser.WorkingHours = new Dictionary<DateTime, TimeRange>();
                //Class that holds the start and end times of the working day.
            hairdresser.Appointments = new Dictionary<DateTime, Appointment>();
            //Dictionary of appointments
            //Assert hashmaps aren't null.
            //Assert a useful value can be retrieved from them.
        }
    }
}
