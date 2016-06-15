using System;
using System.Collections.Generic;

namespace Nebula.FirstEC.Domain.Models.AggregateRoots
{
    public class ShoppingCart : BaseEntity
    {
        public Guid UserId { get; set; }

        public Guid ProductId { get; set; }

        public string ProductName { get; set; }

        public string Specs { get; set; }
    }
}
