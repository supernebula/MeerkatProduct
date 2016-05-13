﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nebula.First.EFRepository.Model;

namespace Nebula.EntityFramework.Repository.Test.Entities
{

    public class TestProduct : BaseEntity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public string Picture { get; set; }

        public string SourceUri { get; set; }

        public int Follows { get; set; }

        public string SourceSite { get; set; }

        public ProductStatusType Status { get; set; }

        public List<SpecValue> Specs { get; set; }

        public int VisitTotal { get; set; }

    }


    public enum ProductStatusType
    {
        Normal,

        SellOut,

        OutOfStock,
    }
}
