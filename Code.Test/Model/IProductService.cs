using System;
using System.Collections.Generic;

namespace Code.Test.Model
{
    public interface IProductService : IDisposable
    {
        Guid Id { get; set; }
        IEnumerable<object> Query(string key);

        int Insert(object item);
    }
}
