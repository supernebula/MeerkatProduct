﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nebula.Common.Cqrs
{
    public interface ICommandHandler<in T> where T : Command
    {
        void Execute(T command);
    }
}
