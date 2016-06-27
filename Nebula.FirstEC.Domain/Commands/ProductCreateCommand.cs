using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nebula.Domain.Commands;

namespace Nebula.FirstEC.Domain.Commands
{
    public class ProductCreateCommand : Command
    {
        public string Title { get; set; }

        public double Price { get; set; }
    }
}
