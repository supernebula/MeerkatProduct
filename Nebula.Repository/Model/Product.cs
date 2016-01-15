using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nebula.Repository.Model
{
    public class Product : BaseEntity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public string Picture { get; set; }

        public string SourceUri { get; set; }

        public string SourceSite { get; set; }

        public ProductStatusType Status { get; set; }

        public IEnumerable<SpecValue> Specs { get; set; }

    }


    public enum ProductStatusType
    {
        Normal,

        SellOut,

        OutOfStock,
    }
}
