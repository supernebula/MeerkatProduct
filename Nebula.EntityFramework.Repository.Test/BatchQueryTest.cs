using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nebula.EntityFramework.Repository.Test.Core;
using Nebula.EntityFramework.Repository.Test.Repositories;

namespace Nebula.EntityFramework.Repository.Test
{
    [TestClass]
    public class BatchQueryTest
    {
        private EfDbContextFactory<FakeEcDbContext> _dbContextFactory;

        [TestInitialize()]
        public void MyTestInitialize()
        {
            _dbContextFactory = new EfDbContextFactory<FakeEcDbContext>();
        }
        [TestMethod]
        public void QueryLargeTest()
        {
            var context = _dbContextFactory.Create();
            var fakeUserRepo = new FakeUserRepository(_dbContextFactory);
            var sw = new Stopwatch();
            sw.Start();
            var result = fakeUserRepo.Take(1000000);
            sw.Stop();
            context.Dispose();
            Trace.WriteLine("QueryLarge " + result.Count + ", 毫秒：" + sw.ElapsedMilliseconds);
        }


        [TestMethod]
        public void SqlQueryLargeTest()
        {
            var context = _dbContextFactory.Create();
            var fakeUserRepo = new FakeUserRepository(_dbContextFactory);
            var sw = new Stopwatch();
            sw.Start();
            var result = fakeUserRepo.TakeByDbSql(1000000);
            sw.Stop();
            context.Dispose();
            Trace.WriteLine("SqlQueryLarge " + result.Count + ", 毫秒：" + sw.ElapsedMilliseconds);
        }
    }
}
