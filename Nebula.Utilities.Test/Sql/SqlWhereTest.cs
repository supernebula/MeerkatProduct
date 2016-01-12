using System;
using Nebula.Utilities.Sql;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nebula.Utilities.Test.Sql
{
    [TestClass]
    public class SqlWhereTest
    {
        [TestMethod]
        public void SelectSimpleTest()
        {
            var sql = SqlWhere.Create("Select * From [Product]")
                .And("Id = @Id", "value").ToSqlString();
            Assert.IsNotNull(sql, "语句为空");
            Trace.WriteLine(sql);
        }
    }
}
