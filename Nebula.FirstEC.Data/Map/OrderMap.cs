using System.Data.Entity.ModelConfiguration;
using Evol.FirstEC.Domain.Models.AggregateRoots;

namespace Evol.FirstEC.Data.Map
{
    public class OrderMap : EntityTypeConfiguration<Order>
    {
        public OrderMap()
        {
            ToTable("Order");
            HasKey(e => e.Id);
            Property(e => e.UserId).IsRequired();
            Property(e => e.ProductId).IsRequired();
           
            Property(e => e.Amount).IsRequired();
            Property(e => e.Number).IsRequired();
            Property(e => e.Recipient).IsRequired().HasMaxLength(100);
            Property(e => e.Address).IsRequired().HasMaxLength(100);
            Property(e => e.Remark).IsRequired().HasMaxLength(100);

            Property(e => e.CreateTime).IsRequired();
            Property(e => e.UpdateTime).IsOptional();
            Property(e => e.DeleteTime).IsOptional();
            Property(e => e.SoftDelete).IsRequired();
        }
    }
}
