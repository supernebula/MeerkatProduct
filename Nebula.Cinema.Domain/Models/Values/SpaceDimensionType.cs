using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Nebula.Cinema.Domain.Models.Values
{
    /// <summary>
    /// 空间维度
    /// </summary>
    public enum SpaceDimensionType
    {
        [Description("2D")]
        [Display(Name = "2D")]
        Movie2D = 0,

        [Description("3D")]
        [Display(Name = "3D")]
        Movie3D = 1,

        [Description("4D")]
        [Display(Name = "4D")]
        Movie4D = 2,

        [Description("5D")]
        [Display(Name = "5D")]
        Movie5D = 3
    }
}
