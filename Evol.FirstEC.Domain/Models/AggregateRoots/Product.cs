using System;
using System.Collections.Generic;
using Evol.FirstEC.Domain.Models.Entities;
using Evol.FirstEC.Domain.Models.Values;

namespace Evol.FirstEC.Domain.Models.AggregateRoots
{
    public class Product : BaseEntity
    {

        #region 基本资料

        public string Title { get; set; }

        public string Description { get; set; }

        public string Picture { get; set; }

        public string SourceUri { get; set; }

        public string SourceSite { get; set; }

        public string Barcode { get; set; }

        #endregion

        #region Price

        public double FixedPrice { get; set; }
        public bool IsDiscount { get; set; }

        public double Discount { get; set; }

        public decimal DiscountPrice { get; set; }

        #endregion

        public ProductStatusType Status { get; set; }

        public Guid CategryId { get; set; }

        public List<ProductTagRelation> Tags { get; set; }

        public List<InStockSpecRelation> Specs { get; set; }

        public InStock InStock { get; set; }

        #region 其他

        public int VisitTotal { get; set; }

        public int Follows { get; set; }

        #endregion


    }


}
