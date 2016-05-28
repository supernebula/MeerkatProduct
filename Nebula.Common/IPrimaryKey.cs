using System;

namespace Nebula.Common
{
    public interface IPrimaryKey
    {
        Guid Id { get; set; }
    }
}
