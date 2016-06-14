﻿using System;
using Nebula.Common;

namespace Nebula.FirstEC.Compoment
{
    public abstract class BaseEntity : IEntity, IPrimaryKey, ISoftDelete
    {
        public Guid Id { get; set; }

        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public DateTime? DeleteTime { get; set; }
        public bool SoftDelete { get; set; }

    }
}
