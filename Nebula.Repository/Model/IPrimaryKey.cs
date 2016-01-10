using System;

namespace Nebula.Repository.Model
{
    public interface IPrimaryKey
    {
        Guid ID { get; set; }
    }
}
