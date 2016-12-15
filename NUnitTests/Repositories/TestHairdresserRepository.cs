using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HSRestAPI_DLL.Entities;
using HSRestAPI_DLL.Interfaces;
using HSRestAPI_DLL.Repositories;
using Moq;
using NUnit.Framework;

namespace NUnitTests.Repositories
{

    [TestFixture]
    public class TestHairdresserRepository
    {
        private static Mock<IRepository<Hairdresser>> mock;
        private static IList<Hairdresser> hairdressers = new List<Hairdresser>();
        private static IRepository<Hairdresser> hdRepo;
        [SetUp]  // [OneTimeSetUp] for NUnit 3.0 and up; see http://bartwullems.blogspot.com/2015/12/upgrading-to-nunit-30-onetimesetup.html
        public void SetUp()//TestContext context
        {
            hairdressers.Clear();
            mock = new Mock<IRepository<Hairdresser>>();
            mock.Setup(x => x.GetAll().Count).Returns(() => hairdressers.Count);
            mock.Setup(x => x.Create(It.IsAny<Hairdresser>())).Callback<Hairdresser>((s) => hairdressers.Add(s));
            mock.Setup(x => x.Get(It.IsAny<int>())).Returns((int id) => hairdressers.FirstOrDefault(x => x.ID == id));
            mock.Setup(x => x.GetAll()).Returns(() => hairdressers.ToList());
            mock.Setup(x => x.Remove(It.IsAny<Hairdresser>())).Callback<Hairdresser>((s) => hairdressers.Remove(s));
            hdRepo = mock.Object;
        }

        /// <summary>
        /// Test method testing the creation of a StudentManager with an existing repository.
        /// </summary>
        [Test]
        public void Create_StudentManager_Existing_Repository_Test()
        {
            hdRepo = mock.Object;
            Assert.IsNotNull(hdRepo);
            Assert.AreEqual(0, hdRepo.GetAll().Count);
        }

        /// <summary>
        /// Test method testing creation of a StudentManager with no repository (null).
        /// Expects ArgumentNullException to be thrown.
        /// </summary>
        //[Test]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void Create_StudentManager_No_Repository_Expect_ArgumentNullException_Test()
        //{
        //    IRepository<Student> repository = null;

        //    Assert.Fail("Created StudentManager with NULL repository");
        //}

        /// <summary>
        /// Test method testing adding a new student to the repository.
        /// </summary>
        [Test]
        public void AddStudent_New_Student_Test()
        {
            Hairdresser hairdresser = new Hairdresser();

            hdRepo.Create(hairdresser);

            Assert.AreEqual(1, hdRepo.GetAll().Count);
            Assert.AreEqual(hairdresser, hdRepo.Get(hairdresser.ID));
        }

        /// <summary>
        /// Test method adding an existing student to the repository.
        /// Expects an ArgumentException to be thrown.
        /// </summary>
        [Test]
        public void AddStudent_Existing_Student_Expect_ArgumentException_Test()
        {
             //new Repository<Student>();
            Hairdresser hairdresser = new Hairdresser();

            hdRepo.Create(hairdresser);

            try
            {
                hdRepo.Create(hairdresser); // try to add the same student again
                Assert.Fail("Added existing student to repository");
            }
            catch (ArgumentException)
            {
                Assert.AreEqual(1, hdRepo.GetAll().Count);
                Assert.AreEqual(hairdresser, hdRepo.Get(hairdresser.ID));
            }
        }

        /// <summary>
        /// Test method testing the retrieval of all students from the repository.
        /// </summary>
        [Test]
        public void GetAllStudents_Test()
        {
            Hairdresser hairdresser1 = new Hairdresser();
            Hairdresser hairdresser2 = new Hairdresser();
            hdRepo.Create(hairdresser1);
            hdRepo.Create(hairdresser2);

            IList<Hairdresser> result = hdRepo.GetAll();

            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(hairdresser1, result[0]);
            Assert.AreEqual(hairdresser2, result[1]);
        }

        /// <summary>
        /// Test method testing retrieval of an existing student with a specific Id.
        /// </summary>
        [Test]
        public void GetStudentById_Existing_Student_Test()
        {
            Hairdresser hairdresser1 = new Hairdresser();
            Hairdresser hairdresser2 = new Hairdresser();
            hdRepo.Create(hairdresser1);
            hdRepo.Create(hairdresser2);

            Hairdresser result = hdRepo.Get(2);

            Assert.AreEqual(hairdresser2, result);
        }

        /// <summary>
        /// Test method testing the retrieval on a non-existing student.
        /// Expects an ArgumentException to be thrown.
        /// </summary>
        [Test]
        public void GetStudentById_NonExisting_Student_Returns_NULL_Test()
        {
            Hairdresser hairdresser1 = new Hairdresser();
            Hairdresser hairdresser2 = new Hairdresser();
            hdRepo.Create(hairdresser1);

            Hairdresser result = hdRepo.Get(2);

            Assert.AreEqual(null, result);
        }

        /// <summary>
        /// Test method testing removal of an existing student.
        /// </summary>
        [Test]
        public void RemoveStudent_Existing_Student_Test()
        {
            Hairdresser hairdresser1 = new Hairdresser();
            Hairdresser hairdresser2 = new Hairdresser();
            hdRepo.Create(hairdresser1);
            hdRepo.Create(hairdresser2);

            hdRepo.Remove(hairdresser2);

            Assert.AreEqual(1, hdRepo.GetAll().Count);
            Assert.AreEqual(hairdresser1, hdRepo.GetAll()[0]);
        }

        /// <summary>
        /// Test method testing removal of a non-existing student.
        /// Expects an ArgumentException to be thrown.
        /// </summary>
        [Test]
        public void RemoveStudent_NonExisting_Student_Expect_ArgumentException_Test()
        {
            Hairdresser hairdresser1 = new Hairdresser();
            Hairdresser hairdresser2 = new Hairdresser();
            hdRepo.Create(hairdresser1);

            try
            {
                hdRepo.Remove(hairdresser2);
                Assert.Fail("Removed non-existing student");
            }
            catch (ArgumentException)
            {
                Assert.AreEqual(1, hdRepo.GetAll().Count);
                Assert.AreEqual(hairdresser1, hdRepo.GetAll()[0]);
            }
        }
    }
}

