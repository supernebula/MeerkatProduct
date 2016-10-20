using System;
using Evol.Common;

namespace Evol.FirstEC.Domain.Models.Entities
{
    public class CategaryTagRelation : IPrimaryKey
    {
        public Guid Id { get; set; }

        public Guid CategaryId { get; set; }

        public Guid TagId { get; set; }
    }
}
