using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity.Infrastructure;
using Nebula.EntityFramework.Repository.Test.Core;
using Nebula.EntityFramework.Repository.Test.Repositories;
using Nebula.EntityFramework.Repository.Test.Entities;

namespace Nebula.EntityFramework.Repository.Test
{
    [TestClass]
    public class BasicFuncTest
    {
        [TestMethod]
        public void InsertUserTest()
        {
            var articleRepo = new FakeArticleOriginalEfRepository(new FakeEcDbContext());
            var user = new FakeArticle()
            {
                Id = Guid.NewGuid(),
                Author = "zhangsan",
                Title = "文章标题1",
                Content = "文章内容1",
                Tag ="经济,医疗",
                CreateDate = DateTime.Now,
                MarkDelete = false,
            };
            articleRepo.Insert(user);
            articleRepo.SaveChanges();
            articleRepo.Dispose();
        }
    }
}
