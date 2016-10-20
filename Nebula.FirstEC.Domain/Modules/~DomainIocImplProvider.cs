//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection;
//using System.Text;
//using System.Threading.Tasks;
//using Evol.Common;
//using Evol.Domain.Ioc;
//using Evol.FirstEC.Domain.QueryEntries;

//namespace Evol.FirstEC.Domain.Configuration
//{
//    public class DomainIocImplProvider : IIocImplProvider
//    {
//        public List<InterfaceImplPair> Filter(Assembly assembly)
//        {
//            Func<Type, bool> filter = (type) => type.IsPublic && !type.IsAbstract && type.IsClass && typeof(IQueryEntry).IsAssignableFrom(type);
//            var impls = assembly.GetTypes().Where(filter).ToList();
//            var interfaceImpls = new List<InterfaceImplPair>();
//            if (impls.Count == 0)
//                return interfaceImpls;
//            impls.ForEach(t =>
//            {
//                var @interface = t.GetInterfaces().SingleOrDefault(i => i.IsGenericType && typeof(IQueryEntry).IsAssignableFrom(i));
//                interfaceImpls.Add(new InterfaceImplPair(){ Interface = @interface, Impl = t});
//            });
//            return interfaceImpls;
//        }
//    }
//}
