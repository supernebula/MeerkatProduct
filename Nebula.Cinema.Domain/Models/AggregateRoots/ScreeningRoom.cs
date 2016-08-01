using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nebula.Cinema.Domain.Models.Entitys;
using Nebula.Cinema.Domain.Models.Values;

namespace Nebula.Cinema.Domain.Models.AggregateRoots
{
    public class ScreeningRoom
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public SpaceDimensionType SpaceDimension { get; set; }

        public List<Seat> Seats { get; set; }

        public SpaceDimensionType SpaceType { get; set; }
    }
}
