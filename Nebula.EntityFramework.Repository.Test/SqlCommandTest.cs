﻿using System;
using System.Data.SqlClient;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nebula.EntityFramework.Repository.Test.Core;
using Nebula.EntityFramework.Repository.Test.Entities;
using Nebula.Utilities.Sql;

namespace Nebula.EntityFramework.Repository.Test
{
    [TestClass]
    public class SqlCommandTest
    {
        [TestMethod]
        public void SqlQueryEntitiesTest()
        {
            using (var context = new FakeEcDbContext())
            {
                var users = context.Set<FakeUser>().SqlQuery("SELECT * TOP 10 FROM [FakeUser]").ToList();
                var users2 = context.Set<FakeUser>().SqlQuery("SELECT * TOP 10 FROM [FakeUser] WHERE [Username] = @username", new SqlParameter("@username", "zhangsan")).ToList();
            }
        }

        [TestMethod]
        public void StoredProceduleTest()
        {
            using (var context = new FakeEcDbContext())
            {
                var users = context.Set<FakeUser>().SqlQuery("dbo.GetUsers").ToList();
                var userId = 1;
                //带参数的存储过程
                var users2 = context.Set<FakeUser>().SqlQuery("dbo.GetUsers @p0", userId).ToList();
            }
        }

        [TestMethod]
        public void SqlQueriesForNoEntityTypeTest()
        {
            using (var context = new FakeEcDbContext())
            {
                var users =
                    context.Database.SqlQuery<string>("SELECT [Name] FROM [FakeUser] WHERE [Id] = @id",
                        new SqlParameter("@id", 1)).FirstOrDefault();
            }
        }

        [TestMethod]
        public void SqlCommandInsertTest()
        {
            using (var context = new FakeEcDbContext())
            {
                var num = context.Database.ExecuteSqlCommand("INSERT INTO [FakeUser]([Id], [Username], [Password], [Address], [Mobile], [Email], [Points], [MarkDelete], [CreateDate]) VALUES(@username, @password, @address, @mobile, @email, @points, @markDelete, @createDate)",
                    new SqlParameter("@Id", Guid.NewGuid()),
                    new SqlParameter("@username", "李四"),
                    new SqlParameter("@password", "123456"),
                    new SqlParameter("@address", "XXXX路ZZ号"),
                    new SqlParameter("@mobile", "13911112222"),
                    new SqlParameter("@email", "lisi@gmial.com"),
                    new SqlParameter("@points", 3),
                    new SqlParameter("@markDelete", false),
                    new SqlParameter("@createDate", DateTime.Now)
                    );
            }
        }


        [TestMethod]
        public void SqlCommandQueryTest()
        {
            using (var context = new FakeEcDbContext())
            {
                var num = context.Database.ExecuteSqlCommand("INSERT INTO [FakeUser]([Id], [Username], [Password], [Address], [Mobile], [Email], [Points], [MarkDelete], [CreateDate]) VALUES(@username, @password, @address, @mobile, @email, @points, @markDelete, @createDate)",
                    new SqlParameter("@Id", Guid.NewGuid()),
                    new SqlParameter("@username", "李四"),
                    new SqlParameter("@password", "123456"),
                    new SqlParameter("@address", "XXXX路ZZ号"),
                    new SqlParameter("@mobile", "13911112222"),
                    new SqlParameter("@email", "lisi@gmial.com"),
                    new SqlParameter("@points", 3),
                    new SqlParameter("@markDelete", false),
                    new SqlParameter("@createDate", DateTime.Now)
                    );
            }
        }


        private void QueryMethod(Guid id, string username, string mobile, int minPoints, int maxPoints, string minCreateDate)
        {
            var sqlWhere = SqlWhereBuilder.Create()
                .And("[Id] = {0}", "@id", id)
                .And("[Username] = @username", "@username", username)
                .And("[Points] >= {0}", "@minPoints", minPoints)
                .And("[Points] <= @maxPoints", "@maxPoints", maxPoints)
                .And("[CreateDate] <= @minCreateDate", "@minCreateDate", minCreateDate);
            using (var context = new FakeEcDbContext())
            {
                var num = context.Database.ExecuteSqlCommand("SELECT * FROM [FakeUser] " + sqlWhere.ToWhereString(), sqlWhere.ToSqlParameters());
            }
        }
    }
}
