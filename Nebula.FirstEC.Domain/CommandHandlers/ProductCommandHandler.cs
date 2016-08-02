using System;
using Nebula.Domain.Messaging;
using Nebula.FirstEC.Domain.Commands;

namespace Nebula.FirstEC.Domain.CommandHandlers
{
    public class ProductCommandHandler : ICommandHandler<ProductCreateCommand>
    {
        public void Execute(ProductCreateCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
