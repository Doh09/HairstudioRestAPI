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
    public class TestMessage
    {
        [Test]
        public void TestProperties()
        {
            /*Message (for website, e.g. welcome messagge) : AbstractEntity
            - Description
             */
            Message message = new Message();
            message.ID = 0;
            message.Description = "Message Description";
            Assert.AreEqual(message.ID, 0);
            Assert.AreEqual(message.Description, "Message Description");
        }
    }
}
