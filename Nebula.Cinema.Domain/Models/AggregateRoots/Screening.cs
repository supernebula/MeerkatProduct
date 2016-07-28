using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nebula.Cinema.Domain.Models.AggregateRoots
{
    public class Screening
    {
        public Guid Id { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }


        public Guid ScreeningRoomId { get; set; }

        public Guid MovieId { get; set; }

        public double Price { get; set; }

        public double SellPrice { get; set; }
    }
}
