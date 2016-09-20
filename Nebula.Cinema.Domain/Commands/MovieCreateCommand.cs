using Nebula.Cinema.Domain.Models.AggregateRoots;
using Nebula.Domain.Commands;

namespace Nebula.Cinema.Domain.Commands
{
    public class MovieCreateCommand : Command
    {
        public Movie AggregateRoot { get; set; }
    }
}
