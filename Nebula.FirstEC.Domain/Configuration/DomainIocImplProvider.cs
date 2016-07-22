using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Nebula.Common;
using Nebula.FirstEC.Domain.QueryEntries;
using Nebula.Utilities.Ioc;

namespace Nebula.FirstEC.Domain.Configuration
{
    public class DomainIocImplProvider : IIocImplProvider
    {
        public List<InterfaceImplPair> Filter(Assembly assembly)
        {
            Func<Type, bool> filter = (type) => type.IsPublic && !type.IsAbstract && type.IsClass && typeof(IQueryEntry).IsAssignableFrom(type);
            var impls = assembly.GetTypes().Where(filter).ToList();
            var interfaceImpls = new List<InterfaceImplPair>();
            if (impls.Count == 0)
                return interfaceImpls;
            impls.ForEach(t => t.GetInterfaces().Any(i => i.IsGenericType && in));
            throw new NotImplementedException();
        }
    }
}
