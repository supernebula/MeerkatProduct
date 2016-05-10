﻿using System;
using Nebula.Utilities.Sql;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nebula.First.EFRepository;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Nebula.Utilities.Test.Sql
{
    [TestClass]
    public class DapperSqlWhereTest
    {
        [TestMethod]
        public void SelectSimpleTest()
        {
            var param = new { Id = Guid.NewGuid(), Name = "手机" };

            var sql = DapperSqlWhereBuilder.Create("Select * From [Product]")
                .And("Id = @Id", "value").Like("Name", "@Name", param.Name)
                .ToSqlString();
            Assert.IsNotNull(sql, "语句为空");
            Trace.WriteLine(sql);
        }

        public void SelectParameterTest()
        {
            
        }
    }
}
