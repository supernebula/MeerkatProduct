using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nebula.Common.Cqrs;
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
