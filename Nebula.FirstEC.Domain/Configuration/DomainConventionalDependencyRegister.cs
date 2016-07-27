using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Nebula.Common;
using Nebula.Domain.Ioc;
using Nebula.FirstEC.Domain.QueryEntries;
using Nebula.FirstEC.Domain.Repositories;

namespace Nebula.FirstEC.Domain.Configuration
{
    public class DomainConventionalDependencyRegisterr : IConventionalDependencyRegister
    {
        public void Register(IUnityContainer container, Assembly assembly)
        {
            throw new NotImplementedException();
        }

        private List<InterfaceImplPair> FindQueryEntry(Assembly assembly)
        {
            Func<Type, bool> filter = (type) => type.IsPublic && !type.IsAbstract && type.IsClass && typeof(IQueryEntry).IsAssignableFrom(type);
            var impls = assembly.GetTypes().Where(filter).ToList();
            var interfaceImpls = new List<InterfaceImplPair>();
            if (impls.Count == 0)
                return interfaceImpls;
            impls.ForEach(t =>
            {
                var @interface = t.GetInterfaces().SingleOrDefault(i => i.IsGenericType && typeof(IQueryEntry).IsAssignableFrom(i));
                interfaceImpls.Add(new InterfaceImplPair() { Interface = @interface, Impl = t });
            });
            return interfaceImpls;
        }

        private List<InterfaceImplPair> FindRepository(Assembly assembly)
        {
            Func<Type, bool> filter = (type) => type.IsPublic && !type.IsAbstract && type.IsClass && typeof(IRepository<>).IsAssignableFrom(type);
            var impls = assembly.GetTypes().Where(filter).ToList();
            var interfaceImpls = new List<InterfaceImplPair>();
            if (impls.Count == 0)
                return interfaceImpls;
            impls.ForEach(t =>
            {
                var @interface = t.GetInterfaces().SingleOrDefault(i => i.IsGenericType && typeof(IQueryEntry).IsAssignableFrom(i));
                interfaceImpls.Add(new InterfaceImplPair() { Interface = @interface, Impl = t });
            });
            return interfaceImpls;
        }
    }
}
