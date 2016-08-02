using Nebula.Domain.Events;

namespace Nebula.Domain.Messaging
{
    public interface IEventBus
    {
        void Publish<T>(T @event) where T : Event;
    }
}
