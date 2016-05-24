using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nebula.Utilities.Maths;

namespace Nebula.Utilities.Test.Maths
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


        [TestMethod]
        public void RandomLetterTest()
        {
            string str = String.Empty;
            for (int i = 0; i < 10; i++)
            {
                 str = RandomUnitily.RandomLetter(8, 15);
                Trace.WriteLine(str);
                Trace.WriteLine(":" + str.Length);
            }
            Assert.IsTrue(str != null && str.Length >= 8 && str.Length <= 15, "长度不不符合");
        }
    }
}
