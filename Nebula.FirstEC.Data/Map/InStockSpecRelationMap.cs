using System.Data.Entity.ModelConfiguration;
using Nebula.FirstEC.Domain.Models.Entities;

namespace Nebula.FirstEC.Data.Map
{
    public class InStockSpecRelationMap : EntityTypeConfiguration<InStockSpecRelation>
    {
        public InStockSpecRelationMap()
        {
            ToTable("InStockSpecRelation");
            HasKey(e => e.Id);
            Property(e => e.InStockId).IsRequired();
            Property(e => e.ProductId).IsRequired();
            Property(e => e.SpecId).IsRequired();
            Property(e => e.ProductId).IsRequired();
            Property(e => e.SpecValue).IsRequired().HasMaxLength(100);
        }
    }
}
