using System;
using Nebula.Common;

namespace Nebula.FirstEC.Compoment
{
    public interface IEntity : IPrimaryKey, IMarkDelete
    {
        DateTime CreateDate { get; set; }
    }
}
