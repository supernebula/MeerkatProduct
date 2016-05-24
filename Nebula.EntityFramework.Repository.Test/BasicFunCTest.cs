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
        private Guid _id;
        public void Init()
        {
            _id = new Guid("C7365C4633084F9F8B0509F1220610F9");
        }

        [TestMethod,Description("实体插入测试")]
        public void InsertEntityTest()
        {
            var articleRepo = new FakeArticleOriginalEfRepository(new FakeEcDbContext());
            var artcle = new FakeArticle()
            {
                Id = _id,
                Author = "zhangsan",
                Title = "文章标题1",
                Content = "文章内容1",
                Tag ="经济,医疗",
                CreateDate = DateTime.Now,
                MarkDelete = false,
            };
            articleRepo.Insert(artcle);
            articleRepo.SaveChanges();
            articleRepo.Dispose();
        }

        [TestMethod, Description("实体查找测试")]
        public void FindEntityTest()
        {
            var articleRepo = new FakeArticleOriginalEfRepository(new FakeEcDbContext());
            var article = articleRepo.Find(_id);
            articleRepo.Dispose();
            Assert.IsNotNull(article, "指定主键的记录不存在");
        }

        [TestMethod, Description("实体更新测试")]
        public void UpdateEntityTest()
        {
            var articleRepo = new FakeArticleOriginalEfRepository(new FakeEcDbContext());
            var article = articleRepo.Find(_id);
            article.Title = "文章标题" + DateTime.Now;
            articleRepo.Update(article);
            var num = articleRepo.SaveChanges();
            articleRepo.Dispose();
            Assert.IsTrue(num == 1, "更新失败，数量：" + num);
        }

        [TestMethod, Description("实体删除测试")]
        public void DeleteEntityTest()
        {
            var articleRepo = new FakeArticleOriginalEfRepository(new FakeEcDbContext());
            var article = articleRepo.Find(_id);
            article.Title = "文章标题" + DateTime.Now;
            articleRepo.Delete(article);
            var num = articleRepo.SaveChanges();
            articleRepo.Dispose();
            Assert.IsTrue(num == 1, "删除失败，数量：" + num);
        }


        [TestMethod, Description("实体查找测试")]
        public void FindEntityTest2()
        {
            var articleRepo = new FakeArticleOriginalEfRepository(new FakeEcDbContext());
            var article = articleRepo.FindAsync(_id);
            articleRepo.Dispose();
            Assert.IsNotNull(article, "指定主键的记录不存在");
        }
    }
}
