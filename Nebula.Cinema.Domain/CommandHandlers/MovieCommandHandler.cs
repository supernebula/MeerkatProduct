using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nebula.Cinema.Domain.Commands;
using Nebula.Domain.Messaging;

namespace Nebula.Cinema.Domain.CommandHandlers
{
    public class MovieCommandHandler : ICommandHandler<MovieCreateCommand>
    {
        public void Execute(MovieCreateCommand command)
        {
            throw new NotImplementedException();
        }

        public Task ExecuteAsync(MovieCreateCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
