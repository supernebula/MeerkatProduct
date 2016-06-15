using System;
using Nebula.Common;

namespace Nebula.FirstEC.Domain.Models.Entities
{
    public class CategarySpecRelation : IPrimaryKey
    {
        public Guid Id { get; set; }

        public Guid CategaryId { get; set; }

        public Guid SpecId { get; set; }
    }
}
