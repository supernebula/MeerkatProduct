using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nebula.Domain.Messaging;

namespace Nebula.Domain.Commands
{
    public class Command : ICommand
    {
        public Command()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }
    }
}
