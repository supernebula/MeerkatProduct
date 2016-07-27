﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Practices.Unity;
using Nebula.Common;
using Nebula.Domain.Ioc;
using Nebula.FirstEC.Domain.QueryEntries;

namespace Nebula.FirstEC.Data.Ioc
{
    public class DataConventionalDependencyRegister : IConventionalDependencyRegister
    {
        public void Register(IUnityContainer container, Assembly assembly)
        {
            Func<Type, bool> filter = (type) => type.IsPublic && !type.IsAbstract && type.IsClass && typeof(IQueryEntry).IsAssignableFrom(type);
            var impls = assembly.GetTypes().Where(filter).ToList();
            var interfaceImpls = new List<InterfaceImplPair>();
            if (impls.Count == 0)
                return;
            impls.ForEach(t =>
            {
                var interfaceType = t.GetInterfaces().FirstOrDefault(i => i.IsGenericType && typeof(IQueryEntry).IsAssignableFrom(i));
                if(interfaceType != null)
                    interfaceImpls.Add(new InterfaceImplPair() { Interface = interfaceType, Impl = t});
            });
            interfaceImpls.ForEach(p => container.RegisterType(p.Interface, p.Impl, new PerResolveLifetimeManager()));
        }
    }
}
