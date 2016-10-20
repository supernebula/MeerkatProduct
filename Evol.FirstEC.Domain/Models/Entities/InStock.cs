using System;
using System.Collections.Generic;

namespace Evol.FirstEC.Domain.Models.Entities
{
    public class InStock : BaseEntity
    {
        public Guid ProductId { get; set; }
        public int Number { get; set; }

        public string Barcode { get; set; }

        public double SellPrice { get; set; }

        public List<InStockSpecRelation> InStockSpecs { get; set; }
}
}
