using System;
using Nebula.Domain.Commands;

namespace Nebula.Cinema.Domain.Commands
{
    public class MovieDeleteCommand : Command
    {
        public Guid AggregateRootId { get; set; }
    }
}
