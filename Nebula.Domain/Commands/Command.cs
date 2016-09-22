using System;
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
