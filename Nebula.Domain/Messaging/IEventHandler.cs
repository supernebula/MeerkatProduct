using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nebula.Domain.Events;

namespace Nebula.Domain.Messaging
{
    public interface IEventHandler<in T> where T : Event
    {
        void Handle(T @event);
    }
}
