﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Practices.Unity;
using Nebula.Common;
using Nebula.Domain.Messaging;

namespace Nebula.Domain.Configuration
{
    public class EventBusDependencyRegister : IDependencyRegister
    {

        public class DefaultEventBusTypeProvider : IDependencyMapProvider
        {
            public IEnumerable<InterfaceClassPair> GetDependencyMap(params Assembly[] assemblies)
            {
                if (assemblies.Any(e => e != null))
                    throw new ArgumentException(nameof(assemblies) + "项均为null， 至少指定一个Assembly");
                var types = new List<Type>();
                assemblies.ToList().ForEach(a => types.AddRange(a.GetExportedTypes()));
                var result = types
                    .Where(t => t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEventBus)))
                    .Select(t => new InterfaceClassPair { InterfaceType = t.GetInterfaces().First(i => i.GetGenericTypeDefinition() == typeof(IEventBus)), ClassType = t });
                return result.ToList();
            }
        }

        private readonly Func<IDependencyMapProvider> _commandBusTypeProviderThunk;
        private readonly Func<IUnityContainer> _containerThunk;
        private readonly Func<Assembly[]> _assembliesThunk;

        public EventBusDependencyRegister(IUnityContainer unityContainer, IDependencyMapProvider commandBusTypeProvider, params Assembly[] assemblies)
        {
            if (unityContainer != null)
                _containerThunk = () => unityContainer;
            if (_commandBusTypeProviderThunk != null)
                _commandBusTypeProviderThunk = () => commandBusTypeProvider;
            _assembliesThunk = () => assemblies;
        }

        public EventBusDependencyRegister(IUnityContainer unityContainer, params Assembly[] assemblies) : this(unityContainer, null, assemblies)
        {
            _commandBusTypeProviderThunk = () => new DefaultEventBusTypeProvider();
        }

        public void Register()
        {
            var commandBusMap = _commandBusTypeProviderThunk().GetDependencyMap(_assembliesThunk()).FirstOrDefault();
            if (commandBusMap == default(InterfaceClassPair))
                throw new NotImplementedException("没有找到" + nameof(IEventBus) + "的实现");
            _containerThunk()
                .RegisterType(commandBusMap.InterfaceType, commandBusMap.ClassType, new PerResolveLifetimeManager());
        }
    }
}
