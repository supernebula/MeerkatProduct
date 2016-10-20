using System.Data.Entity.ModelConfiguration;
using Evol.FirstEC.Domain.Models.Entities;

namespace Evol.FirstEC.Data.Map
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
