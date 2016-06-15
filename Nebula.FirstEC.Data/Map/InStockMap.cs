using System.Data.Entity.ModelConfiguration;
using Nebula.FirstEC.Domain.Models.Entities;

namespace Nebula.FirstEC.Data.Map
{

    public class InStockMap : EntityTypeConfiguration<InStock>
    {
        public InStockMap()
        {
            ToTable("InStock");
            HasKey(e => e.Id);
            Property(e => e.ProductId).IsRequired();
            Property(e => e.Number).IsRequired();
            Property(e => e.ProductId).IsRequired();
            Property(e => e.Barcode).IsRequired().HasMaxLength(100);
            Property(e => e.SellPrice).IsRequired();
            Ignore(e => e.InStockSpecs);

            Property(e => e.CreateTime).IsRequired();
            Property(e => e.UpdateTime).IsOptional();
            Property(e => e.DeleteTime).IsOptional();
            Property(e => e.SoftDelete).IsRequired();
        }
    }
}
