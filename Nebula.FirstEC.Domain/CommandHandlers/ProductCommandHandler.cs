using System;
using System.Threading.Tasks;
using Evol.Domain.Messaging;
using Evol.FirstEC.Domain.Commands;

namespace Evol.FirstEC.Domain.CommandHandlers
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
