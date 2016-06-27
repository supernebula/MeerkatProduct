using Nebula.Domain.Events;

namespace Nebula.Domain.Messaging
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
