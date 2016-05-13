using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nebula.EntityFramework.Repository.Test.Entities;

namespace Nebula.EntityFramework.Repository.Test.Map
{
    public class TestProductMap : EntityTypeConfiguration<TestProduct>
    {
        public TestProductMap()
        {
            this.ToTable("Product");
            this.HasKey(e => e.ID);
            this.Property(e => e.Title).IsRequired().HasMaxLength(100).HasColumnName("Name");
            this.Property(e => e.Description).IsOptional().HasMaxLength(8000);
            this.Property(e => e.SourceUri).HasMaxLength(500);
            this.Property(e => e.SourceSite).HasMaxLength(100);
            this.Property(e => e.Picture).HasMaxLength(500);
            this.Property(e => e.CreateDate).IsRequired();


            this.ToTable("Product");
            this.Property(e => e.Price).HasColumnName("Price").HasColumnAnnotation("商品价格", "value");
            this.Property(e => e.CreateDate).HasPrecision(10);
            this.Ignore(e => e.Specs);
        }


    }
}
