using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using Code.Test.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Practices.Unity;

namespace Code.Test
{
    [TestClass]
    public class UnitTest1
    {


        [TestMethod]
        public void UnityTest()
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType<IProductService, ProductService>();
            var ids = new List<Guid>();

            for (int i = 0; i < 1000; i++)
            {
                var product = container.Resolve<IProductService>();
                
                var id = product.Id;
                if(i % 100 == 0)
                    Trace.WriteLine("");
                Trace.Write(i + ":" + id.GetHashCode() + "|");
                Assert.IsFalse(ids.Any(e => e == product.Id), "hash重复，失败");
                ids.Add(id);
                
            }
            ids = null;
            container.Dispose();
            container = null;

            Trace.WriteLine("Game over--------------------------------------");



            GC.Collect();
            GC.Collect();
            GC.Collect();
            GC.Collect();
            GC.Collect();
            GC.Collect();

            Thread.Sleep(10000);

        }
    }
}
