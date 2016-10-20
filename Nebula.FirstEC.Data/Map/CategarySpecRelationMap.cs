using System.Data.Entity.ModelConfiguration;
using Evol.FirstEC.Domain.Models.Entities;

namespace Evol.FirstEC.Data.Map
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
