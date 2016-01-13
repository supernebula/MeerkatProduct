using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics;

namespace SyntaxTest.cs
{
    [TestClass]
    public class UnitTest1
    {
        class MyObject
        {
            public int Value { get; set; }
        }

        IEnumerable<MyObject> GetYieldObjects()
        {
            for (int i = 0; i < 10; i++)
            {
                Trace.WriteLine("GetYieldObjects i = " + i);
                yield return new MyObject() { Value = i };
            }    
        }

        [TestMethod]
        public void YieldTest()
        {
            var objects = GetYieldObjects();
            foreach (var item in objects)
            {
                Trace.WriteLine(" foreach (var item in objects) item.Value = " + item.Value);
                item.Value += 10;
            }
        }
    }
}
