using System;
using System.Linq.Expressions;
using System.Diagnostics;
using Nebula.Repository.Model;
using Nebula.Utilities.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nebula.Utilities.Test.Expressions
{
    [TestClass]
    public class DynamicExpressionTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            Expression<Func<int, int, int, int, int>> f = (a, b, c, d) => a * b * c + c * d;

        }

        [TestMethod]
        public void DynamicExpressionJoinTest()
        {
            var exp = QueryPredicateBuilder.True<Product>()
                .And(p => p.Price > 1500)
                .And(p => p.Title.Contains("xiaomi"))
                .And(prop => prop.Picture.Contains("jd.com") && prop.Picture.Length > 1);
            Trace.WriteLine(exp.Body);
        }


        [TestMethod]
        public void LambdaPredicateBuilderTest()
        {
            

            var price = 1500;
            string title = null;
            var predicate = LambdaPredicateBuilder.True<Product>()
                .And(p => p.Price > price)
                //.And(p => p.Title == title)
                .And(p => p.SourceSite == "www.jd.com")
                .And(p => p.Picture == null);
            Trace.WriteLine(predicate.Body);
        }

        public class QueryParameter
        {
            public double Price { get; set; }

            public string SourceSite { get; set; }

            public string Picture { get; set; }
        }

        [TestMethod]
        public void LambdaPredicateBuilderParameterTest()
        {
            var query = new QueryParameter() {
                Price = 1500,
                SourceSite = "www.jd.com",
                Picture = null
            };

            var predicate = LambdaPredicateBuilder.True<Product>()
                .And(p => p.Price > query.Price)
                .And(p => p.SourceSite == query.SourceSite)
                .And(p => p.Picture == query.Picture);
            Trace.WriteLine(predicate.Body);
        }

    }




}
