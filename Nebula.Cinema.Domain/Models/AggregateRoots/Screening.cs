﻿using System;
using Evol.Cinema.Domain.Models.Values;
using Evol.Common;

namespace Evol.Cinema.Domain.Models.AggregateRoots
{
    public class Screening : IPrimaryKey
    {
        public Guid Id { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public Guid ScreeningRoomId { get; set; }

        public Guid MovieId { get; set; }

        public double Price { get; set; }

        public double SellPrice { get; set; }


        public SpaceDimensionType SpaceType { get; set; }
    }
}
