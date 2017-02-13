using System;
using Evol.MongoDB.Repository;
using Evol.MongoDB.Test.Entities;
using Evol.MongoDB.Test.Repository;
using Evol.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Evol.MongoDB.Test
{
    [TestClass]
    public class FunctionTest
    {
        private static UserRepository userRepository;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {

            userRepository = new UserRepository(new DefaultMongoDbContextFactory());
        }

        [TestMethod]
        public void AddOneTest()
        {
            var gender = FakeUtility.CreateGender();
            var item = new User()
            {
                Username = FakeUtility.CreateUsername(5, 10),
                Password = FakeUtility.CreatePassword(),
                Email = FakeUtility.CreateEmail(),
                Name = FakeUtility.CreatePersonName(gender),
                Gender = gender,
                Age = FakeUtility.RandomInt(18, 50),
                CreateTime = DateTime.Now
            };

            userRepository.AddAsync(item).GetAwaiter().GetResult();
            Assert.IsTrue(true);
        }
    }
}
