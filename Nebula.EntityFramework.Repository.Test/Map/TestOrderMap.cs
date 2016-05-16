﻿using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nebula.EntityFramework.Repository.Test.Entities;

namespace Nebula.EntityFramework.Repository.Test.Map
{
    public class TestOrderMap : EntityTypeConfiguration<TestOrder>
    {
        public TestOrderMap()
        {
            this.ToTable("TestOrder");
            this.HasKey(e => e.Id);
            this.Property(e => e.ProductId).IsRequired();
            this.Property(e => e.UserId).IsRequired();
            this.Property(e => e.Recipient).IsRequired().HasMaxLength(100).HasColumnName("Recipient");
            this.Property(e => e.Address).IsRequired().HasMaxLength(500);
            this.Property(e => e.Amount).IsRequired();
            this.Property(e => e.Number).IsRequired();
            this.Property(e => e.Remark).IsOptional();
            this.Property(e => e.CreateDate).IsRequired();
            this.Property(e => e.CreateDate).HasPrecision(10);
        }
    }
}