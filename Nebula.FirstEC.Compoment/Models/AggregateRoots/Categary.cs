using System;

namespace Nebula.FirstEC.Domain.Models.AggregateRoots
{
    public class Categary : BaseEntity
    {

        public Guid ParentId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

    }
}
