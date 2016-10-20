using System.Data.Entity.ModelConfiguration;
using Evol.FirstEC.Domain.Models.AggregateRoots;

namespace Evol.FirstEC.Data.Map
{
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            ToTable("Product");
            HasKey(e => e.Id);
            Property(e => e.Title).IsRequired().HasMaxLength(100);
            Property(e => e.Description).IsOptional().HasMaxLength(8000);
            Property(e => e.Picture).HasMaxLength(500);
            Property(e => e.SourceUri).HasMaxLength(500);
            Property(e => e.SourceSite).HasMaxLength(100);
            Property(e => e.Barcode).IsOptional().HasMaxLength(100);

            Property(e => e.FixedPrice).IsRequired().HasColumnAnnotation("商品价格", "value"); ;
            Property(e => e.IsDiscount).IsRequired();
            Property(e => e.Discount).IsRequired();
            Property(e => e.DiscountPrice).IsRequired();

            Property(e => e.Status).IsRequired();
            Property(e => e.CategryId).IsRequired();

            Ignore(e => e.Tags);
            Ignore(e => e.Specs);
            Ignore(e => e.InStock);

            Property(e => e.VisitTotal).IsRequired();
            Property(e => e.Follows).IsRequired();

            Property(e => e.CreateTime).IsRequired().HasPrecision(10);
            Property(e => e.UpdateTime).IsOptional();
            Property(e => e.DeleteTime).IsOptional();
            Property(e => e.SoftDelete).IsRequired();
        }        
    }
}
