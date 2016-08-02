using System;
using System.Threading.Tasks;
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

        public Task ExecuteAsync(ProductCreateCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
