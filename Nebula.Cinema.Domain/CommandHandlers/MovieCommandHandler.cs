using System;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Nebula.Cinema.Domain.Commands;
using Nebula.Cinema.Domain.Repositories;
using Nebula.Domain.Messaging;

namespace Nebula.Cinema.Domain.CommandHandlers
{
    public class MovieCommandHandler : ICommandHandler<MovieCreateCommand>, ICommandHandler<MovieUpdateCommand>, ICommandHandler<MovieDeleteCommand>
    {
        [Dependency]
        public IMovieRepository MovieRepository { get; set; }

        public void Execute(MovieCreateCommand command)
        {
            command.AggregateRoot.Id = Guid.NewGuid();
            MovieRepository.Insert(command.AggregateRoot);
        }

        public void Execute(MovieUpdateCommand command)
        {
            MovieRepository.Update(command.AggregateRoot);
        }

        public void Execute(MovieDeleteCommand command)
        {
            MovieRepository.Delete(command.AggregateRootId);
        }

        public Task ExecuteAsync(MovieCreateCommand command)
        {
            command.AggregateRoot.Id = Guid.NewGuid();
            MovieRepository.Insert(command.AggregateRoot);
            return Task.FromResult(1);
        }

        public Task ExecuteAsync(MovieUpdateCommand command)
        {
            MovieRepository.Update(command.AggregateRoot);
            return Task.FromResult(1);
        }

        public Task ExecuteAsync(MovieDeleteCommand command)
        {
            MovieRepository.Delete(command.AggregateRootId);
            return Task.FromResult(1);
        }
    }
}
