﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nebula.Common.Cqrs
{
    public class Command : ICommand
    {
        public Guid Id { get; private set; }

        //public int Version { get; private set; }
    }
}
