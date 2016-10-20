using System.Data.Entity.ModelConfiguration;
using Evol.FirstEC.Domain.Models.Entities;

namespace Evol.FirstEC.Data.Map
{
    public class ProductTagRelationMap : EntityTypeConfiguration<ProductTagRelation>
    {
        public ProductTagRelationMap()
        {
            ToTable("ProductTagRelation");
            HasKey(e => e.Id);
            Property(e => e.ProductId).IsRequired();
            Property(e => e.TagId).IsRequired();
            Property(e => e.Value).IsRequired().HasMaxLength(100);
        }
    }
}
