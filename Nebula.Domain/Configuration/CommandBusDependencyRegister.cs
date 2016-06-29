using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Practices.Unity;
using Nebula.Common;
using Nebula.Domain.Messaging;

namespace Nebula.Domain.Configuration
{
    class CommandBusDependencyRegister : IDependencyRegister
    {

        public class DefaultCommandBusTypeProvider : IDependencyMapProvider
        {
            public IEnumerable<InterfaceClassPair> GetDependencyMap(params Assembly[] assemblies)
            {
                if (assemblies.Any(e => e != null))
                    throw new ArgumentException(nameof(assemblies) + "项均为null， 至少指定一个Assembly");
                var types = new List<Type>();
                assemblies.ToList().ForEach(a => types.AddRange(a.GetExportedTypes()));
                var result = types
                    .Where(t => t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ICommandBus)))
                    .Select(t => new InterfaceClassPair { InterfaceType = t.GetInterfaces().First(i => i.GetGenericTypeDefinition() == typeof(ICommandBus)), ClassType = t });
                return result.ToList();
            }
        }

        private readonly Func<IDependencyMapProvider> _commandBusTypeProviderThunk;
        private readonly Func<IUnityContainer> _containerThunk;
        private readonly Func<Assembly> _assemblyThunk;

        public CommandBusDependencyRegister(IUnityContainer unityContainer, IDependencyMapProvider commandBusTypeProvider, Assembly assembly)
        {
            if (unityContainer != null)
                _containerThunk = () => unityContainer;
            if (_commandBusTypeProviderThunk != null)
                _commandBusTypeProviderThunk = () => commandBusTypeProvider;
            _assemblyThunk = () => assembly;
        }

        public CommandBusDependencyRegister(IUnityContainer unityContainer, Assembly assembly) : this(unityContainer, null, assembly)
        {
            _commandBusTypeProviderThunk = () => new DefaultCommandBusTypeProvider();
        }

        public void Register()
        {
            var commandBusMap = _commandBusTypeProviderThunk().GetDependencyMap(_assemblyThunk()).FirstOrDefault();
            if(commandBusMap == default(InterfaceClassPair))
                throw new NotImplementedException("没有找到" + nameof(ICommandBus) + "的实现");
            _containerThunk()
                .RegisterType(commandBusMap.InterfaceType, commandBusMap.ClassType, new PerResolveLifetimeManager());
        }
    }
}
