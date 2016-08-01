using System;
using System.Collections.Generic;
using Nebula.Cinema.Domain.Models.Entitys;
using Nebula.Cinema.Domain.Models.Values;

namespace Nebula.Cinema.Domain.Models.AggregateRoots
{
    public class Movie
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string ForeignName { get; set; }

        public string ReleaseDate { get; set; }

        public string Minutes { get; set; }

        public string ReleaseRegion { get; set; }

        public SpaceDimensionType SpaceDimension { get; set; }

        public List<Actor> Actors { get; set; }

        public string CoverUri { get; set; }

        public List<string> Images { get; set; }

        public string Description { get; set; }

        public List<string> Categorys { get; set; }

        public List<string> Tags { get; set; }

        /// <summary>
        /// 评分
        /// </summary>
        public float Ratings { get; set; }

        public string Language { get; set; }




    }
}
