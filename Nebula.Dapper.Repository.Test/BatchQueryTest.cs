using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nebula.Dapper.Repository.Test
{
    [TestClass]
    public class BatchQueryTest
    {
        private DbContextFactory<FakeEcDbContext> _dbConnectionFactory;

        [TestInitialize()]
        public void MyTestInitialize()
        {
            _dbConnectionFactory = new DbContextFactory<FakeEcDbContext>();
        }
        [TestMethod]
        public void QueryLargeTest()
        {
            var fakeUserRepo = new FakeUserRepository(_dbConnectionFactory);
            var sw = new Stopwatch();
            sw.Start();
            var result = fakeUserRepo.Take(10);
            sw.Stop();
            fakeUserRepo.Dispose();
            Trace.WriteLine("DapperQueryLarge " + result.Count + ", 毫秒：" + sw.ElapsedMilliseconds);
        }
    }
}
