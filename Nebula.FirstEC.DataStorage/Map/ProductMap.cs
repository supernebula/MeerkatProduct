using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nebula.FirstEC.Compoment;
using Nebula.FirstEC.Compoment.AggregateRoots;

namespace Nebula.FirstEC.Data.Map
{
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            this.ToTable("Product");
            this.HasKey(e => e.Id);
            this.Property(e => e.Title).IsRequired().HasMaxLength(100).HasColumnName("Name");
            this.Property(e => e.Description).IsOptional().HasMaxLength(8000);
            this.Property(e => e.SourceUri).HasMaxLength(500);
            this.Property(e => e.SourceSite).HasMaxLength(100);
            this.Property(e => e.Picture).HasMaxLength(500);
            this.Property(e => e.CreateTime).IsRequired();


            this.ToTable("Product");
            this.Property(e => e.FixedPrice).HasColumnName("Price").HasColumnAnnotation("商品价格", "value");
            this.Property(e => e.CreateTime).HasPrecision(10);
            this.Ignore(e => e.Specs);
        }
    }
}
