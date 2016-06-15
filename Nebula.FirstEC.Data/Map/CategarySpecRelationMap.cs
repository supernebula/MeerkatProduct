using System.Data.Entity.ModelConfiguration;
using Nebula.FirstEC.Domain.Models.Entities;

namespace Nebula.FirstEC.Data.Map
{
    public class CategarySpecRelationMap : EntityTypeConfiguration<CategarySpecRelation>
    {
        public CategarySpecRelationMap()
        {
            ToTable("CategarySpecRelation");
            HasKey(e => e.Id);
            Property(e => e.CategaryId).IsRequired();
            Property(e => e.SpecId).IsRequired();
        }
    }
}
