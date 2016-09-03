using System.Threading.Tasks;
using Nebula.Domain.Commands;

namespace Nebula.Domain.Messaging
{
    public interface ICommandBus
    {
        void Send<T>(T command) where T : Command;

        Task SendAsync<T>(T command) where T : Command;
    }
}
