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
    public class TestServiceOffered
    {
        [Test]
        public void TestProperties()
        {
            /*ServiceOffered : IEntity
            - Message
            - Price
             */
            ServiceOffered serviceOffered = new ServiceOffered();
            serviceOffered.ID = 0;
            Message m =
                new Message()
                {

                };
            serviceOffered.Message = "test";
            serviceOffered.Price = 159.99;
            Assert.AreEqual(serviceOffered.ID, 0);
            Assert.AreEqual(serviceOffered.Message, "test");
            Assert.AreEqual(serviceOffered.Price, 159.99);
        }
    }
}
