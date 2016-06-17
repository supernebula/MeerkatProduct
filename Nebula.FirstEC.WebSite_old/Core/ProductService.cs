using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nebula.FirstEC.WebSite.Core
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
    }
}
