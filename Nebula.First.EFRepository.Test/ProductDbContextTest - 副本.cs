using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nebula.Repository;
using Nebula.Repository.Model;
using System.Data.Entity;

namespace Nebula.Repository.Test
{
    [TestClass]
    public class ProductDbContextTest
    {

        public DbSet<Product> DbSet
        {
            get
            {
                return ProductDbContext.Instance.Set<Product>();
            }
        }



        [TestMethod]
        public void InsertProductTest()
        {
            var model = new Product() {
                Id = Guid.NewGuid(),
                Name = "小米Note高配版手机",
                Description = "小米Note高配版手机,7天无理由退货",
                Price = 1999.00,
                SourceUri = "http://www.jd.com/2323.html",
                SourceSite = "www.jd.com",
                CreateDate = DateTime.Now,
                Picture = "http://wwww.jd.com/wwe3e.jpg"
            };
            DbSet.Add(model);
            var count = ProductDbContext.Instance.SaveChanges();
        }

        [TestMethod]
        public void ExcuteSqlQueryTest()
        {
            //var result = ProductDbContext.Instance.Database.SqlQuery<Product>("select * from [Product]").ToListAsync().Result;
            var values = DbSet.SqlQuery("select * from [Product]").ToListAsync().Result;
        }

        [TestMethod]
        public void EFSqlTest()
        {
            //var result = ProductDbContext.Instance.Database.SqlQuery<Product>("select * from [Product]").ToListAsync().Result;
            var values = DbSet.ToListAsync().Result;
        }
    }
}
