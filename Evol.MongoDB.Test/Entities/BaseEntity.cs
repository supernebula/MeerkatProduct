using System;
using Evol.Common;

namespace Evol.MongoDB.Test.Entities
{
    public class BaseEntity : IEntity<string>
    {
        public string Id { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
