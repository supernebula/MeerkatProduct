using System;

namespace Nebula.Domain.Messaging
{
    public interface IEvent
    {
        Guid Id { get;}
    }
}
