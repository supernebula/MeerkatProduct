using System;
using Evol.Common;

namespace Evol.FirstEC.Domain.Models.Entities
{
    public class ProductTagRelation : IPrimaryKey
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }

        public Guid TagId { get; set; }

        public string Value { get; set; }
    }
}
