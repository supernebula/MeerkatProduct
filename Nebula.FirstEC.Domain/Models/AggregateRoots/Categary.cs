using System;

namespace Evol.FirstEC.Domain.Models.AggregateRoots
{
    public class Categary : BaseEntity
    {

        public Guid ParentId { get; set; }

        public string Title { get; set; }

        public string Remark { get; set; }

    }
}
