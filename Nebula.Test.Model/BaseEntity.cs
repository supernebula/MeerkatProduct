using System;
using Nebula.Common;

namespace Nebula.Test.Model
{ 
    public abstract class BaseEntity : IPrimaryKey, ISoftDelete
    {
        public Guid Id { get; set; }

        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public DateTime? DeleteTime { get; set; }
        public bool SoftDelete { get; set; }

    }
}
