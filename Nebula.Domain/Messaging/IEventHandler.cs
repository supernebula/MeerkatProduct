using Nebula.Domain.Events;

namespace Nebula.Domain.Messaging
{
    public interface IEventHandler<in T> where T : Event
    {
        void Handle(T @event);
    }
}
