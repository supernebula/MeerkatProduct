using System;
using System.Xml.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nebula.Utilities.Serialization;
using System.Diagnostics;

namespace Nebula.Utilities.Test.Serialization
{
    [TestClass]
    public class XmlUtilityTest
    {
        [TestMethod,Description("XML反序列化")]
        public void DeSerializeTest()
        {
            var xml = "<?xml version=\"1.0\" encoding=\"utf-8\"?><User xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"><Id>C9ECF1D9-513D-489A-B259-5EAE472DFC8A</Id><Gender>None</Gender><CreateDate>2016-01-01T00:00:00</CreateDate></User>";
            var obj = XmlUtility.DeSerialize<User>(xml);
            Trace.Write(obj);
            Assert.IsNotNull(obj);
            
        }


        [TestMethod,Description("序列化XML")]
        public void SerializeTest()
        {
            var user = new User() { CreateDate = DateTime.Now, Gender = GenderType.Female, Id = Guid.NewGuid(), Types = new[] { "1", "2" } };
            var str = XmlUtility.Serialize(user);
            Trace.WriteLine(str);
            Assert.IsTrue(!string.IsNullOrWhiteSpace(str));
            
        }

        [TestMethod,Description("序列化返回干净的XML，不包含Namespace")]
        public void SerializeCleanTest()
        {
            var user = new User() { CreateDate = DateTime.Now, Gender = GenderType.Female, Id = Guid.NewGuid() , Types = new[] {"1", "2"}};
            var str = XmlUtility.SerializeClean(user);
            Trace.WriteLine(str);
            Assert.IsTrue(!string.IsNullOrWhiteSpace(str));
        }
    }

    [XmlRoot("Member")]
    public class User
    {
        public Guid Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        [XmlElement("GenderValue")]
        public GenderType Gender { get; set; }

        [XmlArray, XmlArrayItem("type")]
        public string[] Types { get; set; }

        public DateTime CreateDate { get; set; }
    }

    public enum GenderType
    {
        None,
        Male,
        Female
    }
}
