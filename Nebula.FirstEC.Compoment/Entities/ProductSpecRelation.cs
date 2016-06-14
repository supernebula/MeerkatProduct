using System;
using Nebula.Common;

namespace Nebula.FirstEC.Compoment.Entities
{
    public class ProductSpecRelation : IPrimaryKey
    {
        public Guid Id { get; set; }

        public Guid ProductId { get; set; }

        public Guid SpecId { get; set; }

        public string Value { get; set; }
    }
}
