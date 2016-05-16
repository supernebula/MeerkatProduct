using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nebula.EntityFramework.Repository.Test.Entities;

namespace Nebula.EntityFramework.Repository.Test.Map
{
    public class TestUserMap : EntityTypeConfiguration<TestUser>
    {
        public TestUserMap()
        {
            this.ToTable("TestOrder");
            this.HasKey(e => e.Id);
            this.Property(e => e.Username).IsRequired().HasMaxLength(100);
            this.Property(e => e.Password).IsRequired().HasMaxLength(100);
            this.Property(e => e.Mobile).IsOptional().HasMaxLength(100);
            this.Property(e => e.Email).IsRequired().HasMaxLength(100);
            this.Property(e => e.Address).IsRequired().HasMaxLength(500);
            this.Property(e => e.Points).IsRequired();
            this.Property(e => e.CreateDate).IsRequired();
            this.Property(e => e.CreateDate).HasPrecision(10);
        }
    }
}
