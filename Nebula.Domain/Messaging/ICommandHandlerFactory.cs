using Nebula.Domain.Commands;

namespace Nebula.Domain.Messaging
{
    public interface ICommandHandlerFactory
    {
        ICommandHandler<T> GetHandler<T>() where T : Command;
    }
}
