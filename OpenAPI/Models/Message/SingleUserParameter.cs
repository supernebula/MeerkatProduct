using System.Runtime.Serialization;
using System.Xml.Serialization;
using OpenAPI.Core.API;

namespace OpenAPI.Models.Message
{
    /// <summary>
    /// 单用户消息参数
    /// </summary>
    [DataContract(Name = "SingleUserParameter", Namespace = "")]
    [XmlRoot(ElementName = "SingleUserParameter", Namespace = "")]
    public class SingleUserParameter : IApiParameter
    {
        /// <summary>
        /// 单个社保用户编号
        /// </summary>
        [DataMember(Name = "SiUserId")]
        [XmlElement("SiUserId")]
        public string SiUserId { get; set; }

        /// <summary>
        /// 平台类型
        /// </summary>
        [DataMember(Name = "Platform")]
        [XmlElement("Platform")]
        public int Platform { get; set; }

        /// <summary>
        /// 消息正文
        /// </summary>
        [DataMember(Name = "Content")]
        [XmlElement("Content")]
        public string Content { get; set; }

        #region sign

        /// <summary>
        /// AppKey
        /// </summary>
        [DataMember(Name = "Key")]
        [XmlElement("Key")]
        public string Key { get; set; }
        /// <summary>
        /// MD5签名
        /// </summary>
        [DataMember(Name = "Sign")]
        [XmlElement("Sign")]
        public string Sign { get; set; }

        /// <summary>
        /// 当前时间时间戳，格式：yyyyMMddHHmmss
        /// </summary>
        [DataMember(Name = "Timestamp")]
        [XmlElement("Timestamp")]
        public string Timestamp { get; set; }

        /// <summary>
        /// 随机数
        /// </summary>
        [DataMember(Name = "Nonce")]
        [XmlElement("Nonce")]
        public string Nonce { get; set; }

        #endregion

    }


}