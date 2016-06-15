using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Ajax.Utilities;
using Microsoft.Practices.Unity;
using Nebula.FirstEC.Domain.Models.AggregateRoots;

namespace Nebula.FirstEC.MobileSite.ApiControllers
{
    public class ProductController : ApiController
    {
        // GET: api/Product
        public IEnumerable<Product> Get()
        {
            throw new NotImplementedException();
        }
    }
}
