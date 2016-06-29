using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using Nebula.Domain.Events;
using Nebula.Domain.Configuration;
using Nebula.Domain.Events;

namespace Nebula.Domain.Messaging
{
    public class DefaultEventHandlerFactory : IEventHandlerFactory
    {
        public IEventHandlerActivator EventHandlerActivator { get; set; }

        public DefaultEventHandlerFactory()
        {
            EventHandlerActivator = new DefaultEventHandlerActivator();
        }

        public DefaultEventHandlerFactory(IEventHandlerActivator activator)
        {
            if (activator == null)
                throw new ArgumentNullException(nameof(activator));
            EventHandlerActivator = activator;
        }

        public IEventHandler<T> GetHandler<T>() where T : Event
        {
            return EventHandlerActivator.Create<T>();
        }

        public class DefaultEventHandlerActivator : IEventHandlerActivator
        {
            private readonly Func<IDependencyResolver> _resolverThunk;

            public DefaultEventHandlerActivator()
            {
                _resolverThunk = () => AppConfiguration.Current.DependencyConfiguration.DependencyResolver;
            }

            public DefaultEventHandlerActivator(IDependencyResolver resolver)
            {
                if (resolver == null)
                    throw new ArgumentNullException(nameof(resolver));
                _resolverThunk = () => resolver;
            }

            public IEventHandler<T> Create<T>() where T : Event
            {
                var result = (IEventHandler<T>)_resolverThunk().GetService(typeof(IEventHandler<T>));
                if (result == null)
                    throw new NullReferenceException("未找到实现该接口的类，检查是否依赖注册：" + nameof(IEventHandler<T>));
                return result;
            }
        }
    }
}
