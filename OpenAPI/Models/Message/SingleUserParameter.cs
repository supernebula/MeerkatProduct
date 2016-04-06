using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Xml.Serialization;

namespace OpenAPI.Models.Message
{
    //[DataContract]
    [XmlRoot(Namespace = "")]
    public class SingleUserParameter : BaseSecurityParameter
    {
        [XmlElement(ElementName = "siuserid")]
        [DataMember(Name = "siuserid")]
        public string SiUserId { get; set; }

        [XmlElement(ElementName = "content")]
        [DataMember(Name = "content")]
        public string Content { get; set; }

        #region sign

        /// <summary>
        /// AppKey
        /// </summary>
        [XmlElement(ElementName = "key")]
        public string Key { get; set; }
        /// <summary>
        /// MD5 Sign
        /// </summary>
        [XmlElement(ElementName = "sign")]
        public string Sign { get; set; }

        /// <summary>
        /// yyyyMMddHHmmss
        /// </summary>
        [XmlElement(ElementName = "timestamp")]
        public string Timestamp { get; set; }

        /// <summary>
        /// 随机数
        /// </summary>
        [XmlElement(ElementName = "nonce")]
        public string Nonce { get; set; }

        #endregion

    }


}