﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nebula.Common;

namespace Nebula.FirstEC.Compoment
{
    public abstract class BaseEntity : IEntity, IPrimaryKey, IMarkDelete
    {
        public Guid Id { get; set; }


        public bool MarkDelete { get; set; }


        public DateTime CreateDate { get; set; }

    }
}
