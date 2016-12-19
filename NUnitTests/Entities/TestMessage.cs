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
            /*Message (for website, e.g. welcome messagge) : IEntity
            - ID
            - Description
            - AreaMessageIsUsed
             */
            Message message = new Message();
            message.ID = 1;
            message.Description = "Message Description";
            message.AreaMessageIsUsed = "Area";
            Assert.AreEqual(message.ID, 1);
            Assert.AreEqual(message.Description, "Message Description");
            Assert.AreEqual(message.AreaMessageIsUsed, "Area");
        }
    }
}
