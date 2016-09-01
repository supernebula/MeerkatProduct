using System;
using Nebula.Common;

namespace Nebula.Cinema.Domain.Models.AggregateRoots
{
    public class Actor : IPrimaryKey
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string ImagePath { get; set; }
    }
}
