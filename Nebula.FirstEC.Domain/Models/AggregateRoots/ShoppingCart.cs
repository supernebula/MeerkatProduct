using System;

namespace Nebula.FirstEC.Domain.Models.AggregateRoots
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
