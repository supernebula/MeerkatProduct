using System;
using Nebula.Utilities.Sql;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nebula.Repository;

namespace Nebula.Utilities.Test.Sql
{
    [TestClass]
    public class SqlWhereTest
    {
        [TestMethod]
        public void SelectSimpleTest()
        {
            var param = new { Id = Guid.NewGuid(), Name = "手机" };

            var sql = SqlWhere.Create("Select * From [Product]")
                .And("Id = @Id", "value").Like("Name", "@Name", param.Name)
                .ToSqlString();
            Assert.IsNotNull(sql, "语句为空");
            Trace.WriteLine(sql);
        }

        public void SelectParameterTest()
        {
            
            ProductDbContext.Instance.Database.ExecuteSqlCommand("");
            
        }
    }
}
