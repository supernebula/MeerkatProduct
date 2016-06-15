using System.Data.Entity.ModelConfiguration;
using Nebula.FirstEC.Domain.Models.Entities;

namespace Nebula.FirstEC.Data.Map
{
    public class CategaryTagRelationMap : EntityTypeConfiguration<CategaryTagRelation>
    {
        public CategaryTagRelationMap()
        {
            ToTable("CategaryTagRelation");
            HasKey(e => e.Id);
            Property(e => e.CategaryId).IsRequired();
            Property(e => e.TagId).IsRequired();
        }
    }
}
