using System;
using NUnit.Framework;
namespace NUnitTests
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void TestMethod1()
        {
            int a = 1;
            int b = 1;
            Assert.AreEqual(a,b);
        }
    }
}
