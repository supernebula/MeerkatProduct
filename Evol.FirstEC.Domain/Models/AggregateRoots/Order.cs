using System;


namespace Evol.FirstEC.Domain.Models.AggregateRoots
{
    public class Order : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }

        public int Number { get; set; }
        public double Amount { get; set; }

        public string Recipient { get; set; }
        public string Address { get; set; }

        public string Remark { get; set; }
    }
}
