using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nebula.FirstEC.Compoment.AggregateRoots
{
    public class ShoppingCart : BaseEntity
    {
        public Guid UserId { get; set; }

        public Guid ProductId { get; set; }

        public string ProductName { get; set; }

        public object Color { get; set; }

        public string PackageType { get; set; }
    }
}
