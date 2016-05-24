using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nebula.Common;

namespace Nebula.Utilities.Test
{
    [TestClass]
    public class FakeUtilityTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var names = new List<string>();
            for (int i = 0; i < 100; i++)
            {
                var name = FakeUtility.CreatePersonName(GenderType.Female);
                names.Add(name);
            }
            sw.Stop();
            Trace.WriteLine("耗时：" + sw.Elapsed);
            foreach (var name in names)
            {
                Trace.WriteLine(name);
            }
        }
    }
}
