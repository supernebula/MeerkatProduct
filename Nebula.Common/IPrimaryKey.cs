using System;

namespace Evol.Common
{
    public interface IPrimaryKey
    {
        Guid Id { get; set; }
    }
}
