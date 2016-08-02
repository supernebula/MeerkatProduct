using System;

namespace Nebula.Domain.Messaging
{
    public interface ICommand
    {
        Guid Id { get; }
    }
}
