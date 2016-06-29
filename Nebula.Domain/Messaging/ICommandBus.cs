using Nebula.Domain.Commands;

namespace Nebula.Domain.Messaging
{
    public interface ICommandBus
    {
        void Send<T>(T command) where T : Command;
    }
}
