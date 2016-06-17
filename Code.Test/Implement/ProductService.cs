using System;
using System.Collections.Generic;
using System.Diagnostics;
using Code.Test.Interface;
using Code.Test.Model;

namespace Code.Test.Implement
{
    public class ProductService : IProductService
    {
        public int Insert(object item)
        {
            return 1;
        }

        public IEnumerable<object> Query(string key)
        {
            return new List<object>();
        }


        public int Update(object item)
        {
            return 1;
        }

        public object Find(Guid id)
        {
            return default(object);
        }

        IEnumerable<Product> IProductService.Query(string key)
        {
            throw new NotImplementedException();
        }
    }
}
