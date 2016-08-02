using Nebula.Common.Cqrs;
using Nebula.FirstEC.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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
