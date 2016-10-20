using System.Data.Entity.ModelConfiguration;
using Evol.FirstEC.Domain.Models.AggregateRoots;

namespace Evol.FirstEC.Data.Map
{
    public class SpecMap : EntityTypeConfiguration<Spec>
    {
        public SpecMap()
        {
            ToTable("Spec");
            HasKey(e => e.Id);
            Property(e => e.Name).IsRequired().HasMaxLength(100);
            Property(e => e.Remark).IsRequired().HasMaxLength(100);

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
