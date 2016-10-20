using System;
using Evol.Domain.Messaging;
using Evol.FirstEC.Domain.Events;

namespace Evol.FirstEC.Domain.EventHandlers
{
    public class ProductCreateEventHandler : IEventHandler<ProductCreateEvent>
    {
        public void Handle(ProductCreateEvent @event)
        {
            throw new NotImplementedException();
        }
    }
}
