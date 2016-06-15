using System.Data.Entity.ModelConfiguration;
using Nebula.FirstEC.Domain.Models.AggregateRoots;

namespace Nebula.FirstEC.Data.Map
{

    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            ToTable("User");
            HasKey(e => e.Id);
            Property(e => e.Username).IsRequired().HasMaxLength(100);
            Property(e => e.Password).IsRequired().HasMaxLength(100);
            Property(e => e.Salt).IsRequired().HasMaxLength(100);
            Property(e => e.RealName).IsRequired().HasMaxLength(100);
            Property(e => e.Gender).IsRequired();
            Property(e => e.Mobile).IsRequired().HasMaxLength(100);
            Property(e => e.Email).IsRequired().HasMaxLength(100);
            Property(e => e.Address).IsRequired().HasMaxLength(100);
            Property(e => e.Points).IsRequired();

            Property(e => e.CreateTime).IsRequired();
            Property(e => e.UpdateTime).IsOptional();
            Property(e => e.DeleteTime).IsOptional();
            Property(e => e.SoftDelete).IsRequired();
        }
    }
}
