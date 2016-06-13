using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nebula.FirstEC.Compoment.AggregateRoots
{
    public class Order : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
        public string Recipient { get; set; }

        public double Amount { get; set; }

        public string Address { get; set; }

        public int Number { get; set; }

        public int Remark { get; set; }
    }
}
