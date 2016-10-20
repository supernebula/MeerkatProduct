using System.Data.Entity.ModelConfiguration;
using Evol.FirstEC.Domain.Models.AggregateRoots;

namespace Evol.FirstEC.Data.Map
{
    public class CategaryMap : EntityTypeConfiguration<Categary>
    {
        public CategaryMap()
        {
            ToTable("Categary");
            HasKey(e => e.Id);
            Property(e => e.ParentId).IsRequired();
            Property(e => e.Title).IsRequired().HasMaxLength(100);
            Property(e => e.Remark).IsOptional().HasMaxLength(8000);

            Property(e => e.CreateTime).IsRequired();
            Property(e => e.UpdateTime).IsOptional();
            Property(e => e.DeleteTime).IsOptional();
            Property(e => e.SoftDelete).IsRequired();
        }
    }
}
