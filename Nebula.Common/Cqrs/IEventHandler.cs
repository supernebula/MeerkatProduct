using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nebula.Common.Cqrs
{
    public interface IEventHandler<in T> where T : Event
    {
        void Handle(T @event);
    }
}
