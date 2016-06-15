using System;
using System.Collections.Generic;
using Nebula.FirstEC.Domain.Models.AggregateRoots;
using Nebula.FirstEC.Domain.QueryEntries;

namespace Nebula.FirstEC.Data.QueryEntries
{
    public class ProductQuery : IProductQuery
    {
        public List<Product> Search(string key)
        {
            throw new NotImplementedException();
        }

    }
}
