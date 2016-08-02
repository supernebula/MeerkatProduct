using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Nebula.Common;
using Nebula.Domain.Ioc;
using Nebula.Domain.Messaging;

namespace Nebula.Cinema.Domain.Modules
{
    public class DomainConventionalDependencyRegister : IConventionalDependencyRegister
    {
        public void Register(IUnityContainer container, Assembly assembly)
        {
            var commandHandlerImpls = FindCommandHandler(assembly);
            commandHandlerImpls.ForEach(p => container.RegisterType(p.Interface, p.Impl, new PerResolveLifetimeManager()));

            var eventHandlerImpls = FindEventHandler(assembly);
            eventHandlerImpls.ForEach(p => container.RegisterType(p.Interface, p.Impl, new PerResolveLifetimeManager()));
        }

        private List<InterfaceImplPair> FindCommandHandler(Assembly assembly)
        {
            Func<Type, bool> filter = type => type.IsPublic && !type.IsAbstract && type.IsClass && typeof(ICommandHandler<>).IsAssignableFrom(type);
            var impls = assembly.GetTypes().Where(filter).ToList();
            var interfaceImpls = new List<InterfaceImplPair>();
            if (impls.Count == 0)
                return interfaceImpls;
            impls.ForEach(t =>
            {
                var @interfaces = t.GetInterfaces().Where(i => i.IsGenericType && typeof(ICommandHandler<>).IsAssignableFrom(i)).ToList();
                interfaceImpls.AddRange(@interfaces.Select(@interface => new InterfaceImplPair() { Interface = @interface, Impl = t }));
            });
            return interfaceImpls;
        }

        private List<InterfaceImplPair> FindEventHandler(Assembly assembly)
        {
            Func<Type, bool> filter = type => type.IsPublic && !type.IsAbstract && type.IsClass && typeof(IEventHandler<>).IsAssignableFrom(type);
            var impls = assembly.GetTypes().Where(filter).ToList();
            var interfaceImpls = new List<InterfaceImplPair>();
            if (impls.Count == 0)
                return interfaceImpls;
            impls.ForEach(t =>
            {
                var @interfaces = t.GetInterfaces().Where(i => i.IsGenericType && typeof(IEventHandler<>).IsAssignableFrom(i)).ToList();
                interfaceImpls.AddRange(@interfaces.Select(@interface => new InterfaceImplPair() { Interface = @interface, Impl = t }));
            });
            return interfaceImpls;
        }
    }


}
