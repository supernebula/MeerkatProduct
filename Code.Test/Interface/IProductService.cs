using System;
using System.Collections.Generic;
using Code.Test.Model;

namespace Code.Test.Interface
{
    public interface IProductService
    {
        IEnumerable<Product> Query(string key);

        int Insert(object item);

        int Update(object item);

        object Find(Guid id);
    }
}
