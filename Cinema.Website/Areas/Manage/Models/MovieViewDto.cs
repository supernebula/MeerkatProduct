using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Nebula.Cinema.Domain.Models.AggregateRoots;
using Nebula.Cinema.Domain.Models.Values;

namespace Cinema.Website.Areas.Manage.Models
{
    public class MovieViewDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string ForeignName { get; set; }

        public string ReleaseDate { get; set; }

        public string Minutes { get; set; }

        public string ReleaseRegion { get; set; }

        public SpaceDimensionType SpaceDimension { get; set; }
        public string SpaceDimensionText { get; set; }

        public string CoverUri { get; set; }

        public List<string> Categorys { get; set; }

        public float Ratings { get; set; }

        public string Language { get; set; }

        public string Description { get; set; }

        

        static MovieViewDto()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Movie, MovieViewDto>()
            .AfterMap((o, d) => d.SpaceDimensionText = o.SpaceDimension.ToString()));
        }

        public static MovieViewDto Map(Movie value)
        {
            return Mapper.Map<MovieViewDto>(value);
        }
    }

    public static partial class MovieDtoExtension
    {
        public static MovieViewDto ConvertDto(this Movie value)
        {
            return MovieViewDto.Map(value);
        }

        public static IEnumerable<MovieViewDto> ConvertDto(this IEnumerable<Movie> value)
        {
            return value.Select(e => e.ConvertDto());
        }
    }
}
