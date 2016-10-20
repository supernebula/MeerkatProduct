using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading;
using Code.Test.Implement;
using Code.Test.Interface;
using Code.Test.Model;
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Practices.Unity;
using Evol.FirstEC.Domain;

namespace Code.Test
{
    [TestClass]
    public class DependencyInjectionByReflectionTest
    {
        [TestMethod]
        public void ReflectionUnityTest()
        {

            var interfNspace = "Evol.FirstEC.Domain.Repositories";
            var implNspace = "Evol.FirstEC.Data.Repositories";
            
            //load assembly
            List<Type> types;
            //types =Assembly.GetExecutingAssembly().GetTypes().ToList(); 
            types = new List<Type>();
            var assemblies = new List<Assembly>();
            //assemblies.Add(Assembly.Load("Evol.FirstEC.Data"));
            //assemblies.Add(Assembly.Load("Evol.FirstEC.Domain"));
            System.AppDomain.CurrentDomain.GetAssemblies().ToList().ForEach(assem =>
            {
                types.AddRange(assem.GetTypes());
            });

            //finds all interface with in specity namespaces
            var interfaces = types.Where(t => t.IsPublic && t.IsInterface && t.Namespace == interfNspace).ToList();
            Trace.WriteLine("Interface Total:" + interfaces.Count);
            interfaces.ForEach(e => Trace.WriteLine(e.Name));

            //finds all implement of interface with in assembly
            var implClasses = types.Where(t => t.IsClass && t.IsPublic && t.Namespace == implNspace && t.GetInterfaces().Length > 0).ToList();

            var interfImplmap = new List<KeyValuePair<Type, Type>>();
            interfaces.ForEach(i =>
            {
                var @class = implClasses.FirstOrDefault(t => t.GetInterfaces().Select(e => e.FullName).Contains(i.FullName));
                if(@class != null)
                    interfImplmap.Add(new KeyValuePair<Type, Type>(i, @class));
            });

            Trace.WriteLine("Interface-ImplementClass Total:" + interfImplmap.Count);
            interfImplmap.ForEach(e => Trace.WriteLine(e.Key.FullName + " - " + e.Value.FullName));

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

            //Thread.Sleep(10000);

        }
    }
}
