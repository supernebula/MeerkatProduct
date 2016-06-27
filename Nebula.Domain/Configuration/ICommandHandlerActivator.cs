using Nebula.Domain.Commands;
using Nebula.Domain.Messaging;

namespace Nebula.Domain.Configuration
{
    public interface ICommandHandlerActivator
    {
        ICommandHandler<T> Create<T>() where T : Command;
    }
}
