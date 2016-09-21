using System;
using Nebula.Cinema.Domain.Models.Values;

namespace Nebula.Cinema.Domain.QueryEntries.Parameters
{
    public class MovieQueryParameter
    {
        public string Name { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public string ReleaseRegion { get; set; }

        public SpaceDimensionType? SpaceDimension { get; set; }

        public string Language { get; set; }
    }
}
