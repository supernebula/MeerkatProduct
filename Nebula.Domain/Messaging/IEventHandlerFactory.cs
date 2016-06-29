using System.Collections.Generic;
using Nebula.Domain.Events;

namespace Nebula.Domain.Messaging
{
    public interface IEventHandlerFactory
    {
        IEnumerable<IEventHandler<T>> GetHandler<T>() where T : Event;
    }
}
