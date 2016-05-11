using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nebula.First.Compoment;
using Nebula.First.Data.EntityQueries;

namespace Nebula.First.DataStorage.EntityQueries
{
    public class ProductEntityQuery : IProductEntityQuery
    {
        public List<Product> Search(string key)
        {
            return new List<Product>()
            {
                new Product() { Id = Guid.NewGuid(), Name = "记录一", OriginalPrice = 1001.0m, Description = "描述一", CreateTime = new DateTime(2015, 12, 9)},
                new Product() { Id = Guid.NewGuid(), Name = "记录二", OriginalPrice = 1001.0m, Description = "描述二", CreateTime = new DateTime(2016, 3, 15)},
                new Product() { Id = Guid.NewGuid(), Name = "记录三", OriginalPrice = 1001.0m, Description = "描述三", CreateTime = new DateTime(2016, 4, 1)}
            };
        }
    }
}
