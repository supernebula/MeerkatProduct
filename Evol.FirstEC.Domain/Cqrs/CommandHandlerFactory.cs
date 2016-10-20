using Nebula.Common.Cqrs;
using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;

namespace Nebula.FirstEC.Domain.Cqrs
{
    class CommandHandlerFactory : ICommandHandlerFactory
    {
        public ICommandHandler<T> GetHandler<T>() where T : Command, new()
        {
            var handlerType = GetHandlerType<T>().FirstOrDefault();
            ICommandHandler<T> commandHandler = (ICommandHandler<T>)Activator.CreateInstance(handlerType);
            return commandHandler;
        }


        private List<Type> GetHandlerType<T>() where T : Command, new()
        {
            var assemblies = Assembly.GetExecutingAssembly();
            var types = assemblies.GetTypes()
                .Where(t => t.IsPublic && t.IsClass && !t.IsAbstract && t.GetInterfaces().Any(e => e.IsGenericType && e.GetGenericTypeDefinition() == typeof(ICommandHandler<>)))
                .Where(t => t.GetInterfaces().Any(i => i.GetGenericArguments().Any(p => p == typeof(T))))
                .ToList();
            return types;
        }
    }
}
