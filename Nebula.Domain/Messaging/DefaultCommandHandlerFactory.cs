using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Nebula.Domain.Commands;
using Nebula.Domain.Configuration;

namespace Nebula.Domain.Messaging
{
    public class DefaultCommandHandlerFactory : ICommandHandlerFactory
    {
        public ICommandHandlerActivator CommandHandlerActivator { get; set; }

        public DefaultCommandHandlerFactory() : this(null)
        {
        }

        public DefaultCommandHandlerFactory(ICommandHandlerActivator activator)
        {
            CommandHandlerActivator = activator;
        }

        public ICommandHandler<T> GetHandler<T>() where T :  Command
        {
            CommandHandlerActivator.Create<T>();

            var type = GetHandlerType<T>().FirstOrDefault();
            if (type == null)
                return null;
            return (ICommandHandler<T>)Activator.CreateInstance(type);
        }

        public List<Type> GetHandlerType<T>()
        {
            var assemblies = Assembly.GetExecutingAssembly();
            var types =
                assemblies.GetExportedTypes()
                    .Where(
                        t =>  t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof (ICommandHandler<>)))
                    .Where(t => t.GetInterfaces().Any(i => i.GetGenericArguments().Any(a => a == typeof (T))));
            return types.ToList();
        }

        public class DefaultCommandHandlerActivator : ICommandHandlerActivator
        {
            private readonly Func<IDependencyResolver> _resolverThunk;

            public DefaultCommandHandlerActivator() : this(null)
            {
            }

            public DefaultCommandHandlerActivator(IDependencyResolver resolver)
            {
                if (resolver == null)
                    _resolverThunk = () => DependencyResolver.Current;
                else
                    _resolverThunk = () => resolver;
            }

            public ICommandHandler<T> Create<T>() where T : Command
            {
                var result = (ICommandHandler<T>)_resolverThunk().GetInstance(typeof (ICommandHandler<T>));
                if(result == null)
                    throw new NullReferenceException("未找到实现该接口的类，检查是否依赖注册：" + nameof(ICommandHandler<T>));
                return result;
            }
        }
    }
}
