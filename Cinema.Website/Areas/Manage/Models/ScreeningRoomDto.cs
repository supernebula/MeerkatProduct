using AutoMapper;
using Nebula.Cinema.Domain.Models.AggregateRoots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Website.Areas.Manage.Models
{


    public class ScreeningRoomDto : ScreeningRoom
    {
        public string SpaceDimensionText { get; set; }

        public string SpaceTypeText { get; set; }

        static ScreeningRoomDto()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<ScreeningRoom, ScreeningRoomDto>()
            .AfterMap((o, d) => d.SpaceDimensionText = o.SpaceDimension.ToString())
            .AfterMap((o, d) => d.SpaceTypeText = o.SpaceType.ToString()));
        }

        public static ScreeningRoomDto Map(ScreeningRoom value)
        {
            return Mapper.Map<ScreeningRoomDto>(value);
        }
    }

    public static class ScreeningRoomExtension
    {
        public static ScreeningRoomDto ConvertDto(this ScreeningRoom value)
        {
            return ScreeningRoomDto.Map(value);
        }
    }
}
