﻿using System;
using Nebula.Cinema.Domain.Models.Values;
using Nebula.Common;

namespace Nebula.Cinema.Domain.Models.Entitys
{
    public class Seat : IPrimaryKey
    {
        public Guid Id { get; set; }
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
