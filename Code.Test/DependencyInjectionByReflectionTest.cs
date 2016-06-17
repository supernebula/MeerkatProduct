using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading;
using Code.Test.Implement;
using Code.Test.Interface;
using Code.Test.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Practices.Unity;

namespace Code.Test
{
    [TestClass]
    public class DependencyInjectionByReflectionTest
    {

        public void ReflectionUnityTest()
        {

            //finds all interface with in specity namespaces
            var types =Assembly.GetExecutingAssembly().GetTypes();
            types.ToList().ForEach(e => e.GetInterface(""));

            //load assembly

            //finds all implement of interface with in assembly



        }



        [TestMethod]
        public void HandCodeUnityTest()
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType<IProductService, ProductService>();
            var ids = new List<Guid>();

            for (int i = 0; i < 1000; i++)
            {
                var product = container.Resolve<IProductService>();
            }
            ids = null;
            container.Dispose();
            container = null;

            Trace.WriteLine("Game over--------------------------------------");
            GC.Collect();

            Thread.Sleep(10000);

        }
    }
}
