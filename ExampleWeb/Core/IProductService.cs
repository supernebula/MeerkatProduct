using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleWeb.Core
{
    public interface IProductService
    {
        Guid Id { get; set; }
        IEnumerable<object> Query(string key);

        int Insert(object item);
    }
}
