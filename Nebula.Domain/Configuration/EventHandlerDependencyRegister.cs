using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Nebula.Common;
using Nebula.Domain.Messaging;

namespace Nebula.Domain.Configuration
{
    public class EventHandlerDependencyRegister : IDependencyRegister
    {
        public class DefaultEventHandlerTypeProvider : IDependencyMapProvider
        {
            public IEnumerable<InterfaceClassPair> GetDependencyMap(params Assembly[] assemblies)
            {
                if (assemblies.Any(e => e != null))
                    throw new ArgumentException(nameof(assemblies) + "项均为null， 至少指定一个Assembly");
                var types = new List<Type>();
                assemblies.ToList().ForEach(a => types.AddRange(a.GetExportedTypes()));
                var result = types
                    .Where(t => t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ICommandHandler<>)))
                    .Select(t => new InterfaceClassPair { InterfaceType = t.GetInterfaces().First(i => i.GetGenericTypeDefinition() == typeof(ICommandHandler<>)), ClassType = t });
                return result.ToList();
            }
        }


        private readonly Func<IDependencyMapProvider> _eventHandlerTypeProviderThunk;
        private readonly Func<IUnityContainer> _containerThunk;
        private readonly Func<Assembly[]> _assembliesThunk;
        public EventHandlerDependencyRegister(IUnityContainer unityContainer, IDependencyMapProvider commandHandlerTypeProvider, params Assembly[] assemblies)
        {
            if (unityContainer != null)
                _containerThunk = () => unityContainer;
            if (commandHandlerTypeProvider != null)
                _eventHandlerTypeProviderThunk = () => commandHandlerTypeProvider;
            _assembliesThunk = () => assemblies;
        }

        public EventHandlerDependencyRegister(IUnityContainer unityContainer, params Assembly[] assemblies) : this(unityContainer, null, assemblies)
        {
            _eventHandlerTypeProviderThunk = () => new DefaultEventHandlerTypeProvider();
        }

        public EventHandlerDependencyRegister(IDependencyMapProvider commandHandlerTypeProvider, params Assembly[] assemblies) : this(null, commandHandlerTypeProvider, assemblies)
        {
            _containerThunk = () => DependencyConfiguration.Current.UnityContainer;
        }

        public EventHandlerDependencyRegister(params Assembly[] assemblies) : this(null, null, assemblies)
        {
            _containerThunk = () => DependencyConfiguration.Current.UnityContainer;
            _eventHandlerTypeProviderThunk = () => new DefaultEventHandlerTypeProvider();
        }

        public void Register()
        {
            var container = _containerThunk();
            var maps = _eventHandlerTypeProviderThunk().GetDependencyMap(_assembliesThunk()).ToList();
            maps.ForEach(e => container.RegisterType(e.InterfaceType, e.ClassType, new PerResolveLifetimeManager()));
        }
    }
}
