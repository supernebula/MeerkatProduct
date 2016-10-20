using System;
using System.Collections.Generic;
using Evol.FirstEC.Domain.Models.AggregateRoots;
using Evol.FirstEC.Domain.QueryEntries;

namespace Evol.FirstEC.Data.QueryEntries
{
    public class ProductQuery : IProductQuery
    {
        public List<Product> Search(string key)
        {
            throw new NotImplementedException();
        }

    }
}
