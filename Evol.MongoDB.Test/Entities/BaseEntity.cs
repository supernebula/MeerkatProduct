using System;
using Evol.Common;

namespace Evol.MongoDB.Test.Entities
{
    public class BaseEntity : IPrimaryKey<string>
    {
        public virtual string Id { get; set; }

        public virtual DateTime CreateTime { get; set; }
    }
}
