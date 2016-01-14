using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nebula.Repository;
using Nebula.Repository.Model;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Linq;

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
        public void DbSetSqlQueryTest()
        {
            var count = DbSet.Count();
            //var result = ProductDbContext.Instance.Database.SqlQuery<Product>("select * from [Product]").ToListAsync().Result;
            var values = DbSet.SqlQuery("select * from [Product]").ToListAsync().Result;
        }





        #region EF Insert


        [TestMethod]
        public void InsertProductTest()
        {
            var model = new Product()
            {
                ID = new Guid("8B0F4C10-3CC1-4EC9-8767-566AF07AABCB"),
                Name = "华为荣耀9手机 国产精品",
                Description = "华为荣耀9手机，国产精品,7天无理由退货",
                Price = 1999.00,
                SourceUri = "http://www.jd.com/4431.html",
                SourceSite = "www.jd.com",
                CreateDate = DateTime.Now,
                Picture = "http://wwww.jd.com/4431-qaw.jpg"
            };
            DbSet.Add(model);
            var count = ProductDbContext.Instance.SaveChanges();
        }

        #endregion

        #region EF Modify


        [TestMethod]
        public void ModifyProductTest()
        {
            using(var context = ProductDbContext.Instance)
            {
                var model = context.Set<Product>().Find(new Guid("8B0F4C10-3CC1-4EC9-8767-566AF07AABCB"));
                model.Price = 2499.00;
                context.SaveChanges();
            }
        }

        #endregion

        #region EF Remove


        [TestMethod]
        public void RemovByResultProductTest()
        {
            using (var context = ProductDbContext.Instance)
            {
                var model = context.Set<Product>().Find(new Guid("8B0F4C10-3CC1-4EC9-8767-566AF07AABCB"));
                context.Set<Product>().Remove(model);
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void RemoveByKeyProductTest()
        {
            using (var context = ProductDbContext.Instance)
            {
                var model = new Product() { ID = new Guid("8B0F4C10-3CC1-4EC9-8767-566AF07AABCB") };
                context.Set<Product>().Attach(model);
                //附加关联数据
                //context.Entry(product)
                //    .Collection(p => p.Specs)
                //    .Load();

                context.Set<Product>().Remove(model);
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void RemoveByStatusProductTest()
        {
            using (var context = ProductDbContext.Instance)
            {
                var model = new Product() { ID = new Guid("8B0F4C10-3CC1-4EC9-8767-566AF07AABCB") };
                context.Entry(model).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void RemoveBySqlProductTest()
        {
            using (var context = ProductDbContext.Instance)
            {
                //两句相同
                context.Database.ExecuteSqlCommand("DELETE FROM [Product] WHERE [Id] = {0}", new Guid("8B0F4C10-3CC1-4EC9-8767-566AF07AABCB"));
                //context.Database.ExecuteSqlCommand("DELETE FROM [Product] WHERE [Id] = {0}", "8B0F4C10-3CC1-4EC9-8767-566AF07AABCB");
            }
        }

        #endregion

        #region EF Query

        public class TempProduct
        {
            public string Name { get; set; }

            public double Price { get; set; }

        }

        [TestMethod]
        public void DbPartialSqlQueryTest()
        {
            var list = ProductDbContext.Instance.Database.SqlQuery<TempProduct>("SELECT [Name],[Price] From [Product]").ToArrayAsync().Result;
        }


        [TestMethod]
        public void DbPartialLinqQueryTest()
        {
            using(var context = ProductDbContext.Instance)
            {
                var list = context.Set<Product>().Where(e => e.Name.Contains("手机") && e.Price > 1500).OrderBy(e => e.Price).ThenByDescending(e => e.Name).Select(e => new TempProduct { Name = e.Name, Price = e.Price });
                foreach (var item in list)
                {
                    Debug.WriteLine("Name:{0},Price:{1}", item.Name, item.Price);
                }
            }
        }


        [TestMethod]
        public void DbQueryToMemoryTest()
        {
            using (var context = ProductDbContext.Instance)
            {
                context.Set<Product>().Where(e => e.Name.Contains("手机") && e.Price > 1500).OrderBy(e => e.Price).ThenByDescending(e => e.Name).Load();

                Debug.WriteLine("从内存读取");
                foreach (Product item in context.Set<Product>().Local)
                {
                    Debug.WriteLine("Name:{0},Price:{1}", item.Name, item.Price);
                }

                context.Set<Product>().Local.Clear();
            }
        }

        [TestMethod]
        public void DbSetFindTest()
        {
            using (var context = ProductDbContext.Instance)
            {
                var entity = context.Set<Product>().Find(new Guid("8b0f4c10-3cc1-4ec9-8767-566af07aabcb"));
                Assert.IsNotNull(entity, "没有任何数据");
                Trace.WriteLine("Find(8B0F4C10-3CC1-4EC9-8767-566AF07AABCB):");
                Trace.WriteLine(String.Format("Name:{0},Price:{1}", entity.Name, entity.Price));

            }
        }

        [TestMethod]
        public void DbParamSqlQueryTest()
        {
            var list = ProductDbContext.Instance.Database.SqlQuery<TempProduct>("SELECT [Name],[Price] From [Product] WHERE [Price] > {0}", 1500).ToListAsync().Result;
        }

        [TestMethod]
        public void DbParamSqlQueryTest2()
        {
            var list = ProductDbContext.Instance.Database.ExecuteSqlCommand("");
               // Database.SqlQuery<TempProduct>("SELECT [Name],[Price] From [Product] WHERE [Price] > {0}", 1500).ToListAsync().Result;
        }


        [TestMethod]
        public void DbSetQueryTest()
        {
            //var result = ProductDbContext.Instance.Database.SqlQuery<Product>("select * from [Product]").ToListAsync().Result;
            var values = DbSet.ToListAsync().Result;
        }

        [TestMethod]
        public void DbNoTrackingQueryTest()
        {
            using (var context = ProductDbContext.Instance)
            {
                var model = context.Set<Product>().AsNoTracking<Product>().Where(e => e.ID == new Guid("8B0F4C10-3CC1-4EC9-8767-566AF07AABCB")).SingleOrDefault();
                Assert.IsNotNull(model, "该记录不存在");
                model.Price = 2499.00;
                context.SaveChanges();//对NoTracking 实体更新，将失败

            }
        }

        [TestMethod]
        public void NoMapTest()
        {
            using(var context = ProductDbContext.Instance)
            {
                var model = context.Set<Spec>().ToList();
            }
        }


        public Expression<Func<Product, bool>> DynamicExpressionQuery()
        {
            var price1 = 1500.00;
            var name1 = "xiaomi";
            Expression<Func<Product, bool>> predicate1 = p => p.Price > price1;
            Expression<Func<Product, bool>> predicate2 = p => p.Name.Contains(name1);

            var invokeExp2 = Expression.Invoke(predicate2, predicate2.Parameters);
            var query = Expression.Lambda<Func<Product, bool>>(Expression.Or(predicate1.Body, invokeExp2), predicate1.Parameters);
            return query;
        }

        [TestMethod]
        public void DynamicQueryTest()
        {
            var query = DynamicExpressionQuery();

            using (var context = ProductDbContext.Instance)
            {
                try
                {
                    var model = context.Set<Product>().AsQueryable().Where(query).ToList();
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(ex.Message);
                }
                
            }
        }

        #endregion
    }
}
