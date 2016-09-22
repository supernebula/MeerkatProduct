using AutoMapper;
using Nebula.Cinema.Domain.Models.AggregateRoots;

namespace Cinema.Website.Areas.Manage.Models
{
    public class ScreeningDto : Screening
    {
        public string SpaceTypeText { get; set; }

        static ScreeningDto()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Screening, ScreeningDto>()
            .AfterMap((o, d) => d.SpaceTypeText = o.SpaceType.ToString()));
        }

        public static ScreeningDto Map(Screening value)
        {
            return Mapper.Map<ScreeningDto>(value);
        }
    }

    public static class ScreeningExtension
    {
        public static ScreeningDto ConvertDto(this Screening value)
        {
            return ScreeningDto.Map(value);
        }
    }
}
