using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nebula.Repository.Model
{
    public class Product
    {
        public Guid ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public string Picture { get; set; }

        public string SourceUri { get; set; }

        public string SourceSite { get; set; }
        public DateTime CreateDate { get; set; }



    }
}
