using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nebula.Utilities.Test.Math
{
    [TestClass]
    public class RandomTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var guid = Guid.NewGuid().ToString();
            Trace.WriteLine("seed:" + guid);

            Trace.WriteLine("第一轮随机:");
            var random = new Random(guid.GetHashCode());
            for (int i = 0; i < 10; i++)
            {
                var num = random.Next(0, 100000);
                Trace.WriteLine(i + ":" + num);
            }


            Trace.WriteLine("第二轮随机:");
            var random2 = new Random(guid.GetHashCode());


            for (int i = 0; i < 10; i++)
            {
                var num = random2.Next(0, 100000);
                Trace.WriteLine(i + ":" + num);
            }
        }
    }
}
