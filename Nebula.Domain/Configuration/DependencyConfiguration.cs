using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Nebula.Utilities;
using Unity.Mvc5;

namespace Nebula.Domain.Configuration
{
    public class DependencyConfiguration
    {
        public IDependencyResolver DependencyResolver { get; }
        public IUnityContainer UnityContainer { get; }

        private IDependencyRegister _commandHandlerDependencyRegister;

        private IDependencyRegister _eventHandlerDependencyRegister;

        public DependencyConfiguration()
        {
            UnityContainer = new UnityContainer();
            DependencyResolver = new UnityDependencyResolver(UnityContainer);
        }

        public DependencyConfiguration(IUnityContainer unityContainer, IDependencyResolver dependencyResolver)
        {
            UnityContainer = unityContainer;
            DependencyResolver = dependencyResolver;
        }

        public T Resolver<T>()
        {
            return UnityContainer.Resolve<T>();
        }

        public void RegisterMessagingComponent(params string[] assemblies)
        {
            if(assemblies.Length == 0)
                throw new ArgumentOutOfRangeException(nameof(assemblies) + "数组为空");
            var asses = new List<Assembly>();
            assemblies.ToList().ForEach(e => asses.Add(Assembly.Load(e)));
            RegisterMessagingComponent(assemblies);
        }

        public void RegisterMessagingComponent(params Assembly[] assemblies)
        {
            if (assemblies.Length == 0)
                throw new ArgumentOutOfRangeException(nameof(assemblies) + "数组为空");
            _commandHandlerDependencyRegister = new CommandHandlerDependencyRegister(UnityContainer, assemblies);
            _commandHandlerDependencyRegister.Register();
            _eventHandlerDependencyRegister = new EventHandlerDependencyRegister(UnityContainer, assemblies);
            _eventHandlerDependencyRegister.Register();
        }

        public void RegisterRepository(string interfaceNamespace, string classNamespace, params string[] assamblies)
        {
            if (assamblies.Length == 0)
                throw new ArgumentOutOfRangeException(nameof(assamblies) + "数组为空");

            var asses = new List<Assembly>();
            assamblies.ToList().ForEach(e => asses.Add(Assembly.Load(e)));
            RegisterRepository(interfaceNamespace, classNamespace, assamblies);
        }

        public void RegisterRepository(string interfaceNamespace, string classNamespace, params Assembly[] assemblies)
        {
            if(string.IsNullOrWhiteSpace(interfaceNamespace))
                throw new ArgumentNullException(nameof(interfaceNamespace));
            if (string.IsNullOrWhiteSpace(classNamespace))
                throw new ArgumentNullException(nameof(classNamespace));
            if (assemblies.Length == 0)
                throw new ArgumentOutOfRangeException(nameof(assemblies) + "数组为空");

            var interfaceClassPaires = IoCUtility.GetInterfaceAndClass( interfaceNamespace, classNamespace, assemblies);
            interfaceClassPaires.ForEach(p => UnityContainer.RegisterType(p.InterfaceType, p.ClassType, new PerThreadLifetimeManager()));
        }

        public void RegisterQueryEntry(string interfaceNamespace, string classNamespace, params string[] assemblies)
        {
            if (string.IsNullOrWhiteSpace(interfaceNamespace))
                throw new ArgumentNullException(nameof(interfaceNamespace));
            if (string.IsNullOrWhiteSpace(classNamespace))
                throw new ArgumentNullException(nameof(classNamespace));
            if (assemblies.Length == 0)
                throw new ArgumentOutOfRangeException(nameof(assemblies) + "数组为空");

            var asses = new List<Assembly>();
            assemblies.ToList().ForEach(e => asses.Add(Assembly.Load(e)));
            RegisterRepository(interfaceNamespace, classNamespace, assemblies);
        }

        public void RegisterQueryEntry(string interfaceNamespace, string classNamespace, params Assembly[] assemblies)
        {
            if (string.IsNullOrWhiteSpace(interfaceNamespace))
                throw new ArgumentNullException(nameof(interfaceNamespace));
            if (string.IsNullOrWhiteSpace(classNamespace))
                throw new ArgumentNullException(nameof(classNamespace));
            if (assemblies.Length == 0)
                throw new ArgumentOutOfRangeException(nameof(assemblies) + "数组为空");

            var interfaceClassPaires = IoCUtility.GetInterfaceAndClass(interfaceNamespace, classNamespace, assemblies);
            interfaceClassPaires.ForEach(p => UnityContainer.RegisterType(p.InterfaceType, p.ClassType, new PerThreadLifetimeManager()));
        }
    }
}
