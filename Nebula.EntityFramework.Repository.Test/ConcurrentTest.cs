using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nebula.EntityFramework.Repository.Test.Core;
using Nebula.EntityFramework.Repository.Test.Entities;
using Nebula.EntityFramework.Repository.Test.Repositories;
using Nebula.Utilities;

namespace Nebula.EntityFramework.Repository.Test
{
    /// <summary>
    /// ConcurrentTest 的摘要说明
    /// </summary>
    [TestClass]
    public class ConcurrentTest
    {

        private EfDbContextFactory<FakeEcDbContext> _dbContextFactory;

        [TestInitialize()]
        public void MyTestInitialize()
        {
            _dbContextFactory = new EfDbContextFactory<FakeEcDbContext>();
        }

        public void MyTestCleanup()
        {

            
        }



        [TestMethod]
        public void BatchInsertTest()
        {
            var total = 100000;
            var context = _dbContextFactory.Create();
            var fakeUserRepo = new FakeUserRepository(_dbContextFactory);
            var sw = new Stopwatch();
            sw.Start();

            var users = CreateOneUser(10000);
            var time1 = sw.ElapsedMilliseconds;
            sw.Restart();
            fakeUserRepo.InsertRange(users);
            context.SaveChanges();
            sw.Stop();
            context.Dispose();

            Trace.WriteLine("Create FakeUser " + total + ", 毫秒：" + sw.ElapsedMilliseconds);
            Trace.WriteLine("Insert " + total + ", 毫秒：" + sw.ElapsedMilliseconds);
        }


        [TestMethod]
        public void InsertOneTest()
        {
            var total = 100000;
            var context = _dbContextFactory.Create();
            var fakeUserRepo = new FakeUserRepository(_dbContextFactory);
            var sw = new Stopwatch();
            sw.Start();

            var user = CreateOneUser();
            fakeUserRepo.Insert(user);
            context.SaveChanges();
            sw.Stop();
            Trace.WriteLine("Insert " + total + ", 毫秒：" + sw.ElapsedMilliseconds);
            context.Dispose();
        }


        private List<FakeUser> CreateOneUser(int total)
        {
            
            var list = new List<FakeUser>();
            if (total < 1)
                return list;
            for (int i = 0; i < total; i++)
            {
                var gender = FakeUtility.CreateGender();
                var fakeUser = new FakeUser()
                {
                    Id = FakeUtility.CreateGuid(),
                    RealName = FakeUtility.CreatePersonName(gender),
                    Username = FakeUtility.CreateUsername(),
                    Password = FakeUtility.CreatePassword(),
                    Address = "XXXX路yy号",
                    Mobile = FakeUtility.CreateMobile(),
                    Email = FakeUtility.CreateEmail(),
                    Points = FakeUtility.RandomInt(0, 100),
                    Birthday = FakeUtility.CreateBirthday(),
                    PersonHeight = FakeUtility.CreatePersonHeight(),
                    CreateDate = DateTime.Now
                };

                list.Add(fakeUser);

            }
            return list;
        }

        private FakeUser CreateOneUser()
        {
            var gender = FakeUtility.CreateGender();
            var fakeUser = new FakeUser()
            {
                Id = FakeUtility.CreateGuid(),
                RealName = FakeUtility.CreatePersonName(gender),
                Username = FakeUtility.CreateUsername(),
                Password = FakeUtility.CreatePassword(),
                Address = "XXXX路yy号",
                Mobile = FakeUtility.CreateMobile(),
                Email = FakeUtility.CreateEmail(),
                Points = FakeUtility.RandomInt(0, 100),
                Birthday = FakeUtility.CreateBirthday(),
                PersonHeight = FakeUtility.CreatePersonHeight(),
                CreateDate = DateTime.Now
            };
            return fakeUser;
        }
    }
}
