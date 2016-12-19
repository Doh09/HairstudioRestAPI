using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using HSRestAPI_DLL.Entities;
namespace NUnitTests.Entities
{
    [TestFixture]
    public class TestTimeRange
    {
        [Test]
        public void TestProperties()
        {
            /*TimeRange : IEntity
            - ID
            - TheDate
            - Start time
            - End time
             */
            TimeRange timeRange = new TimeRange();
            timeRange.ID = 1;
            timeRange.TheDate = DateTime.Now;
            timeRange.StartTime = DateTime.Now;
            timeRange.EndTime = DateTime.Now;

            timeRange.EndTime.AddHours(8);

            Assert.AreEqual(timeRange.ID, 1);
            //Assert start/end times are different.
            Assert.AreNotEqual(timeRange.StartTime, timeRange.TheDate);
            Assert.AreNotEqual(timeRange.StartTime, timeRange.EndTime);
            //Assert dates are set as expected.
            Assert.AreEqual(timeRange.TheDate.Date, DateTime.Now.Date);
            Assert.AreEqual(timeRange.StartTime.Date, DateTime.Now.Date); //Check if start date is set right.
            Assert.AreEqual(timeRange.EndTime.Date, DateTime.Now.Date); //Check if end date is set right.
            //Assert that times can be changed, assert that times are as expected.
        }
    }
}
