using System;
using System.Collections.Generic;
using Nebula.Cinema.Domain.Models.Values;
using Nebula.Common;

namespace Nebula.Cinema.Domain.Models.AggregateRoots
{
    public class Movie : IPrimaryKey
    {
        /// <summary>
        /// 编号
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 外语名称
        /// </summary>
        public string ForeignName { get; set; }

        /// <summary>
        /// 发行日期
        /// </summary>
        public string ReleaseDate { get; set; }

        /// <summary>
        /// 时间长度
        /// </summary>
        public string Minutes { get; set; }

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
        public List<Actor> Actors { get; set; }

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




    }
}
