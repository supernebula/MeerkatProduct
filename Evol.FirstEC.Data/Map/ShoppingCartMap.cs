using System.Data.Entity.ModelConfiguration;
using Evol.FirstEC.Domain.Models.AggregateRoots;

namespace Evol.FirstEC.Data.Map
{
    public class ShoppingCartMap : EntityTypeConfiguration<ShoppingCart>
    {
        public ShoppingCartMap()
        {
            ToTable("ShoppingCart");
            HasKey(e => e.Id);
            Property(e => e.UserId).IsRequired();
            Property(e => e.ProductId).IsRequired();

            Property(e => e.ProductName).IsRequired().HasMaxLength(100);
            Property(e => e.Specs).IsRequired().HasMaxLength(100);

            Property(e => e.CreateTime).IsRequired();
            Property(e => e.UpdateTime).IsOptional();
            Property(e => e.DeleteTime).IsOptional();
            Property(e => e.SoftDelete).IsRequired();

            Property(e => e.CreateTime).IsRequired().HasPrecision(10);
            Property(e => e.UpdateTime).IsOptional();
            Property(e => e.DeleteTime).IsOptional();
            Property(e => e.SoftDelete).IsRequired();
        }

    }


}
