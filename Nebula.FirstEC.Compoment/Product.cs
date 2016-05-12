using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nebula.FirstEC.Compoment
{
    public class Product : Entity
    {
        public string Name { get; set; }

        public decimal OriginalPrice { get; set; }

        public decimal SellPrice { get; set; }

        public string Description { get; set; }
    }
}
