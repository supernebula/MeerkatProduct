using System;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using Evol.MongoDB.Repository;
using Evol.MongoDB.Test.Entities;
using Evol.MongoDB.Test.Repository;
using Evol.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Driver;

namespace Evol.MongoDB.Test
{
    [TestClass]
    public class FunctionTest
    {
        private static UserRepository _userRepository;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {

            _userRepository = new UserRepository(new DefaultMongoDbContextFactory());
            InitData();
        }

        [ClassCleanup]
        public static void ClassClear()
        {
            var list = _userRepository.SelectAsync(null, e => e.Id).GetAwaiter().GetResult().ToList();
            var ids = list.Skip(5).Select(e => e.Id).ToList();
            var deleted = _userRepository.DeleteBatchAsync(ids).GetAwaiter().GetResult();
        }

        private static void InitData()
        {
            for (int i = 0; i < 25; i++)
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

                _userRepository.AddAsync(item).GetAwaiter().GetResult();
                Assert.IsTrue(true);
            }
        }



        private User FakeItem()
        {
            var paged = _userRepository.PagedSelectAsync(null, 1, 1).GetAwaiter().GetResult();
            var first = paged.FirstOrDefault();
            return first;
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

            _userRepository.AddAsync(item).GetAwaiter().GetResult();
            Assert.IsTrue(true);
        }



        [TestMethod]
        public void DeleteOneTest()
        {
            var fakeUser = FakeItem();
            var deleted = _userRepository.DeleteAsync(fakeUser.Id).GetAwaiter().GetResult();
            Assert.IsTrue(deleted);
        }

        [TestMethod]
        public void UpdateOneTest()
        {
            var fakeUser = FakeItem();
            fakeUser.Gender = FakeUtility.CreateGender();
            fakeUser.Password = FakeUtility.CreatePassword();
            fakeUser.Email = FakeUtility.CreateEmail();
            fakeUser.Age = FakeUtility.RandomInt(18, 50);
            fakeUser.CreateTime = DateTime.Now;

            var updated = _userRepository.UpdateAsync(fakeUser).GetAwaiter().GetResult();
            Assert.IsTrue(updated);
        }


        [TestMethod]
        public void FindOneTest()
        {
            var fakeUser = FakeItem();


            var user1 = _userRepository.FindOneAsync(e => e.Email == fakeUser.Email).GetAwaiter().GetResult();
            Assert.IsNotNull(user1);
            Expression<Func<User, bool>> express = u => u.Email == fakeUser.Email;
            FilterDefinition<User> filter = express;

            var user2 = _userRepository.FindOneAsync(filter).GetAwaiter().GetResult();
            Assert.IsNotNull(user2);
        }


        [TestMethod]
        public void SelectAllTest()
        {
            var all = _userRepository.Queryable<User>(null, null).ToList();
            Trace.WriteLine($"user count:{all.Count}");
            foreach (var item in all)
            {
                Trace.WriteLine($"Id:{item.Id}, Username:{item.Username}, Password:{item.Password}, Email:{item.Email}, Name:{item.Name}, Gender:{item.Gender}, Age:{item.Age}, CreateTime:{item.CreateTime}");
            }
            Assert.IsNotNull(all);
        }
    }
}
