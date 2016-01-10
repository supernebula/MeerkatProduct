using System;

namespace Nebula.Repository.Model
{
    public interface IEntity : IPrimaryKey, IMarkDelete
    {
        DateTime CreateDate { get; set; }
    }
}
