using Nebula.Domain.Commands;

namespace Nebula.Domain.Messaging
{
    public interface ICommandHandler<in T> where T : Command
    {
        void Execute(T command);
    }
}
