using Nebula.Utilities.Sql;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nebula.Utilities.Test.Sql
{
    [TestClass]
    public class SqlBuilderTest
    {
        [TestMethod]
        public void SimpleSqlTest()
        {
            var sqlBuilder = SqlBuilder.Create("Select * From Product")
                .And("Name Like '%' + @Name + '%'", "@Name", "手机")
                .And("Price > @Price", "@Price", 1300)
                .AndExpression(s => s.And("Site = @Site", "@Site", "jd.com").Or("Site = @Site", "@Site", "taoba.com"));
                

            var sql = sqlBuilder.ToSqlString();
            Trace.WriteLine(sql);
            var sqlParam = sqlBuilder.ToSqlParameters();
            Trace.WriteLine(sqlParam.Count);
        }
    }
}
