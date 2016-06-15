using System.Data.Entity.ModelConfiguration;
using Nebula.FirstEC.Domain.Models.AggregateRoots;

namespace Nebula.FirstEC.Data.Map
{

    public class TagMap : EntityTypeConfiguration<Tag>
    {
        public TagMap()
        {
            ToTable("Tag");
            HasKey(e => e.Id);
            Property(e => e.Name).IsRequired().HasMaxLength(100);

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
