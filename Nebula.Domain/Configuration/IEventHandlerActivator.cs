using System.Collections.Generic;
using Nebula.Domain.Events;
using Nebula.Domain.Messaging;

namespace Nebula.Domain.Configuration
{
    public interface IEventHandlerActivator
    {
        IEnumerable<IEventHandler<T>> Create<T>() where T : Event;
    }
}
