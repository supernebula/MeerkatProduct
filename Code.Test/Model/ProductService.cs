using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Code.Test.Model
{
    public class ProductService : IProductService
    {
        public Guid Id { get; set; }

        public ProductService()
        {
            Id = Guid.NewGuid();
        }

        public int Insert(object item)
        {
            return 1;
        }

        public IEnumerable<object> Query(string key)
        {
            return new List<object>();
        }

        ~ProductService()
        {
            Trace.WriteLine("Finalize:" + Id.GetHashCode());
        }

        public void Dispose()
        {
            Trace.WriteLine("Dispose:" + Id.GetHashCode());
        }
    }
}
