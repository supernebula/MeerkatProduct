using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nebula.Utilities;
using Nebula.Common;

namespace Nebula.FirstEC.Compoment
{
    public abstract class Entity : IPrimaryKey, ISoftDelete
    {
        public Guid Id { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public DateTime? DeleteTime { get; set; }

        public bool SoftDelete { get; set; }
    }
}
