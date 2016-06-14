using System;
using Nebula.Common;

namespace Nebula.FirstEC.Compoment.Entities
{
    public class CategaryTagRelation : IPrimaryKey
    {
        public Guid Id { get; set; }

        public Guid CategaryId { get; set; }

        public Guid TagId { get; set; }
    }
}
