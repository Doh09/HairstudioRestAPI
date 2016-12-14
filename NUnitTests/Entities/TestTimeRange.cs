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
            - Start time
            - End time
             */
            TimeRange timeRange = new TimeRange();
            timeRange.ID = -1;
            timeRange.StartTime = DateTime.Now;
            timeRange.EndTime = DateTime.Now; //Fix
            timeRange.EndTime.AddHours(8);

            Assert.AreEqual(timeRange.ID, -1);
            Assert.AreNotEqual(timeRange.StartTime, timeRange.EndTime);
            ; //Assert length of work day
            Assert.AreEqual(timeRange.StartTime.Date, DateTime.Now.Date); //Check if start date is set right.
            Assert.AreEqual(timeRange.EndTime.Date, DateTime.Now.Date); //Check if end date is set right.
            //Assert that times can be changed, assert that times are as expected.
        }
    }
}
