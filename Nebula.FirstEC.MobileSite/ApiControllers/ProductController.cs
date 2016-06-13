using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Practices.Unity;
using Nebula.FirstEC.Compoment;
using Nebula.FirstEC.Compoment.AggregateRoots;
using Nebula.FirstEC.Data.EntityQueries;

namespace Nebula.FirstEC.MobileSite.ApiControllers
{
    public class ProductController : ApiController
    {
        [Dependency]
        public IProductEntityQuery ProductEntityQuery { get; set; }

        // GET: api/Product
        public IEnumerable<Product> Get()
        {
            var result = ProductEntityQuery.Search("");
            return result;
        }
    }
}
