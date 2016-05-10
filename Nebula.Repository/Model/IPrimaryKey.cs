using System;

namespace Nebula.First.EFRepository.Model
{
    public interface IPrimaryKey
    {
        Guid ID { get; set; }
    }
}
