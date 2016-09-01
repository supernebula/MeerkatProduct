using System;
using System.Collections.Generic;
using Nebula.Cinema.Domain.Models.Entitys;
using Nebula.Cinema.Domain.Models.Values;
using Nebula.Common;

namespace Nebula.Cinema.Domain.Models.AggregateRoots
{
    public class ScreeningRoom : IPrimaryKey
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public SpaceDimensionType SpaceDimension { get; set; }

        public List<Seat> Seats { get; set; }

        public SpaceDimensionType SpaceType { get; set; }
    }
}
