﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nebula.Common.Cqrs
{
    public interface IEventHandlerFactory
    {
        IEnumerable<IEventHandler<T>> GetHandler<T>() where T : Event;
    }
}