using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Nebula.Common.Cqrs;

namespace Nebula.FirstEC.Domain.Cqrs
{
    public class EventHandlerFactory : IEventHandlerFactory
    {
        public IEnumerable<IEventHandler<T>> GetHandler<T>() where T : Event
        {
            var eventHandlers = new List<IEventHandler<T>>();
            var handlerTyps = GetHandlerType<T>();
            handlerTyps.ForEach(t => eventHandlers.Add((IEventHandler<T>)Activator.CreateInstance(t)));
            return eventHandlers;
        }

        public List<Type> GetHandlerType<T>()
        {
            var assemblies = Assembly.GetExecutingAssembly();
            var types =
                assemblies.GetTypes()
                    .Where(
                        t =>
                            t.IsPublic &&
                            t.GetInterfaces()
                                .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEventHandler<>)))
                    .Where(t => t.GetInterfaces().Any(i => i.GetGenericArguments().Any(a => a == typeof(T))));
            return types.ToList();
        }
    }
}
