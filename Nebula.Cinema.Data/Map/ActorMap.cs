using Nebula.Cinema.Domain.Models.AggregateRoots;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nebula.Cinema.Data.Map
{
    public class ActorMap : EntityTypeConfiguration<Actor>
    {
        public ActorMap()
        {
            ToTable("Actor");
            HasKey(e => e.Id);
            Property(e => e.Name).IsRequired();
            Property(e => e.ImagePath).IsOptional();
        }
    }
}
