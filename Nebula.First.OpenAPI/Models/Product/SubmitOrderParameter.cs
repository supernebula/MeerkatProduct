using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Nebula.First.OpenAPI.Models.Product
{
    /// <summary>
    /// 提交订单参数
    /// </summary>
    [DataContract(Name = "SubmitOrderParameter", Namespace = "")]
    [XmlRoot(ElementName = "SubmitOrderParameter", Namespace = "")]
    public class SubmitOrderParameter
    {
        /// <summary>
        /// 商品编号
        /// </summary>
        [DataMember(Name = "ProductId")]
        [XmlElement("ProductId")]
        public string ProductId { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        [DataMember(Name = "Username")]
        [XmlElement("Username")]
        public string UserId { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        [DataMember(Name = "Number")]
        [XmlElement("Number")]
        public int Number { get; set; }

        /// <summary>
        /// Address
        /// </summary>
        [DataMember(Name = "Address")]
        [XmlElement("Address")]
        public string Address { get; set; }
    }


}