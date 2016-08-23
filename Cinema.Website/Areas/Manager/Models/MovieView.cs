using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Nebula.Cinema.Domain.Models.AggregateRoots;

namespace Cinema.Website.Areas.Manager.Models
{
    public class MovieDto : Movie
    {
        public string SpaceDimensionText { get; set; }

        static MovieDto()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Movie, MovieDto>()
            .AfterMap((o, d) => d.SpaceDimensionText = o.SpaceDimension.ToString()));
        }

        public static MovieDto Map(Movie value)
        {
            return Mapper.Map<MovieDto>(value);
        }
    }

    public static class MovieDtoExtension
    {
        public static MovieDto ConvertDto(this Movie value)
        {
            return MovieDto.Map(value);
        }
    }
}
