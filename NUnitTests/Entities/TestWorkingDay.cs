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
    public class TestWorkingDay
    {
        [Test]
        public void TestProperties()
        {
            /*WorkingDay : AbstractEntity
            - Start time
            - End time
             */
            WorkingDay workingDay = new WorkingDay();
            workingDay.ID = -1;
            workingDay.StartTime = DateTime.Now;
            workingDay.EndTime = DateTime.Now; //Fix
            workingDay.EndTime.AddHours(8);

            Assert.AreEqual(workingDay.ID, -1);
            Assert.AreNotEqual(workingDay.StartTime, workingDay.EndTime);
            ; //Assert length of work day
            Assert.AreEqual(workingDay.StartTime.Date, DateTime.Now.Date); //Check if start date is set right.
            Assert.AreEqual(workingDay.EndTime.Date, DateTime.Now.Date); //Check if end date is set right.
            //Assert that times can be changed, assert that times are as expected.
        }
    }
}
