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
            var exp = ExpressionBuilder<Product>.Create().And(p => p.Price > 1500).And(p => p.Title.Contains("xiaomi"));
            Trace.WriteLine(exp.ToBodyString());
        }

    }

    public class ExpressionCalculator
    {
        public ExpressionCalculator()
        { }

    }


}
