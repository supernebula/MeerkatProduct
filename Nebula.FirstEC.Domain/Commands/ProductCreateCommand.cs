using Nebula.Common.Cqrs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nebula.FirstEC.Domain.Commands
{
    public class ProductCreateCommand : Command
    {
        public string Title { get; set; }

        public double Price { get; set; }
    }
}
