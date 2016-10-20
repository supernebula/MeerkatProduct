using System;
using Evol.Common;

namespace Evol.FirstEC.Domain.Models.Entities
{
    public class InStockSpecRelation : IPrimaryKey
    {
        public Guid Id { get; set; }

        public Guid InStockId { get; set; }

        public Guid ProductId { get; set; }

        public Guid SpecId { get; set; }

        public string SpecValue { get; set; }
    }
}
