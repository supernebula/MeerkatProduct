using System;
using System.Collections.Generic;
using Evol.Cinema.Domain.Models.Entitys;
using Evol.Cinema.Domain.Models.Values;
using Evol.Common;

namespace Evol.Cinema.Domain.Models.AggregateRoots
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
