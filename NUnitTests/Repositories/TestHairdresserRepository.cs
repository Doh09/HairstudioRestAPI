using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HSRestAPI_DLL.Entities;
using HSRestAPI_DLL.Interfaces;
using HSRestAPI_DLL.Repositories;
using NUnit.Framework;

namespace NUnitTests.Repositories
{
    [TestFixture]
    public class TestHairdresserRepository
    {
        [Test]
        public void TestCRUD()
        {
            IRepository<Hairdresser> hairdresserRepo = new HairdresserRepository();
            Hairdresser hairdresser = new Hairdresser()
            {
                ID = 33,
                Appointments = new Dictionary<DateTime, Appointment>(),
                Name = "Hairdresser1",
                UserType = "Hairdresser",
                Email = "Hairdresser@gmail.com",
                Username = "Hairdresser1Username",
                Password = "Hairdresser1Password",
                PhoneNumber = 12344321,
                WorkingHours = new Dictionary<DateTime, WorkingDay>()
            };
            //Test GetAll();
            Assert.AreEqual(0, hairdresserRepo.GetAll().Count);
            Assert.AreNotEqual(1, hairdresserRepo.GetAll().Count);
            //Test Create();
            hairdresserRepo.Create(hairdresser);
            Assert.AreEqual(1, hairdresserRepo.GetAll().Count);
            //Test Get();
            Assert.AreEqual(33, hairdresserRepo.Get(33).ID);
            //Test Update();
            hairdresser.Name = "newname";
            hairdresserRepo.Update(hairdresser);
            Assert.AreEqual("newname", hairdresserRepo.Get(33).Name);
            //Test Remove();
            Assert.IsTrue(hairdresserRepo.Remove(hairdresser));
            Assert.AreEqual(0, hairdresserRepo.GetAll().Count);

        }
    }
}
