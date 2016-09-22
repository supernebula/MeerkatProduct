using Nebula.Cinema.Domain.Models.AggregateRoots;
using Nebula.Domain.Commands;

namespace Nebula.Cinema.Domain.Commands
{
    public class MovieUpdateCommand : Command
    {
        public Movie AggregateRoot { get; set; }
    }
}
