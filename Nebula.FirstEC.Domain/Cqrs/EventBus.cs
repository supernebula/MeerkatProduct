using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nebula.Common.Cqrs;

namespace Nebula.FirstEC.Domain.Cqrs
{
    public class EventBus : IEventBus
    {
        public IEventHandlerFactory EventHandlerFactory { get; set; }
        public void Publish<T>(T @event) where T : Event
        {
            var eventHandlers = EventHandlerFactory.GetHandler<T>();
            foreach (var handler in eventHandlers)
            {
                handler.Handle(@event);
            }
        }
    }
}
