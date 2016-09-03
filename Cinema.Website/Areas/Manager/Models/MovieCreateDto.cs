using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Nebula.Cinema.Domain.Models.AggregateRoots;
using Nebula.Cinema.Domain.Models.Values;

namespace Cinema.Website.Areas.Manager.Models
{
    public class MovieCreateDto
    {
        /// <summary>
        /// 编号
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [Required]
        [Display(Name = "名称")]
        public string Name { get; set; }

        /// <summary>
        /// 外语名称
        /// </summary>
        [Required]
        [Display(Name = "外语名称")]
        public string ForeignName { get; set; }

        /// <summary>
        /// 发行日期
        /// </summary>
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "发行日期")]
        public DateTime ReleaseDate { get; set; }

        /// <summary>
        /// 时间长度
        /// </summary>
        [Required]
        public int Minutes { get; set; }

        /// <summary>
        /// 发行地区
        /// </summary>
        public string ReleaseRegion { get; set; }

        /// <summary>
        /// 空间维度
        /// </summary>
        public SpaceDimensionType SpaceDimension { get; set; }

        /// <summary>
        /// 演员
        /// </summary>
        public List<Guid> ActorIds { get; set; }

        /// <summary>
        /// 封面图片地址
        /// </summary>
        public string CoverUri { get; set; }

        /// <summary>
        /// 图片
        /// </summary>
        public List<string> Images { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 分类
        /// </summary>
        public List<string> Categorys { get; set; }

        /// <summary>
        /// 标签
        /// </summary>
        public List<string> Tags { get; set; }

        /// <summary>
        /// 评分
        /// </summary>
        public float Ratings { get; set; }

        /// <summary>
        /// 语言
        /// </summary>
        public string Language { get; set; }

        static MovieCreateDto()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Movie, MovieCreateDto>());
        }

        public static MovieCreateDto Map(Movie value)
        {
            return Mapper.Map<MovieCreateDto>(value);
        }
    }

    public static partial class MovieDtoExtension
    {
        public static MovieCreateDto ConvertCreateDto(this Movie value)
        {
            return MovieCreateDto.Map(value);
        }

        public static IEnumerable<MovieCreateDto> ConvertCreateDto(this IEnumerable<Movie> value)
        {
            throw new NotImplementedException();
        }
    }
}