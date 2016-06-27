using System;
using Nebula.Domain.Messaging;
using Nebula.FirstEC.Domain.Events;

namespace Nebula.FirstEC.Domain.EventHandlers
{
    public class ProductCreateEventHandler : IEventHandler<ProductCreateEvent>
    {
        public void Handle(ProductCreateEvent @event)
        {
            throw new NotImplementedException();
        }
    }
}
