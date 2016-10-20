using System.Data.Entity.ModelConfiguration;
using Evol.FirstEC.Domain.Models.Entities;

namespace Evol.FirstEC.Data.Map
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
