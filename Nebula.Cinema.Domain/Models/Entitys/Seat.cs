using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nebula.Cinema.Domain.Models.Values;

namespace Nebula.Cinema.Domain.Models.Entitys
{
    public class Seat
    {
        public SeatType SeatType { get; set; }

        public int RowNo { get; set; }

        public int ColumnNo { get; set; }

        public SeatStatusType Status { get; set; }
    }

    public enum SeatStatusType
    {
        Enabled = 0,

        Disabled = 1
    }
}
