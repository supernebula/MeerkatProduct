using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nebula.Utilities.Serialization;
using System.Diagnostics;

namespace Nebula.Utilities.Test.Serialization
{
    [TestClass]
    public class XmlConvertTest
    {
        [TestMethod]
        public void DeSerializeTest()
        {
            var xml = "<?xml version=\"1.0\" encoding=\"utf-8\"?><User xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"><Id>C9ECF1D9-513D-489A-B259-5EAE472DFC8A</Id><Gender>None</Gender><CreateDate>2016-01-01T00:00:00</CreateDate></User>";
            var obj = XmlConvert.DeSerialize<User>(xml);
            Assert.IsNotNull(obj);
            Debug.Write(obj);
        }


        [TestMethod]
        public void SerializeTest()
        {
            var user = new User() { CreateDate = DateTime.Now, Gender = GenderType.Female, Id = Guid.NewGuid() };
            var str = XmlConvert.Serialize(user);
            Assert.IsTrue(!String.IsNullOrWhiteSpace(str));
            Debug.WriteLine(str);
        }
    }


    public class User
    {
        public Guid Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public GenderType Gender { get; set; }

        public DateTime CreateDate { get; set; }
    }

    public enum GenderType
    {
        None,
        Male,
        Female
    }
}
