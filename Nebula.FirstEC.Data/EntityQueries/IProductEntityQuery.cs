using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Nebula.FirstEC.Compoment;

namespace Nebula.FirstEC.Data.EntityQueries
{
    public interface IProductEntityQuery
    {
        List<Product> Search(string key);
    }
}
