using System;

namespace Nebula.First.EFRepository.Model
{
    public interface IEntity : IPrimaryKey, IMarkDelete
    {
        DateTime CreateDate { get; set; }
    }
}
