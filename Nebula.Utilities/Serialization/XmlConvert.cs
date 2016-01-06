using System;
using System.IO;
using System.Xml;
using System.Text;
using System.Xml.Serialization;


namespace Nebula.Utilities.Serialization
{
    public static class XmlConvert
    {



        public static string Serialize(object obj)
        {
            string result = null;
            var setting = new XmlWriterSettings();
            setting.Encoding = Encoding.Default;
            setting.CloseOutput = true;
            setting.OmitXmlDeclaration = true;
            var ms = new MemoryStream();
            using (var writer = XmlWriter.Create(ms, setting))
            {
                var ns = new XmlSerializerNamespaces();
                ns.Add(String.Empty, String.Empty);
                var ser = new XmlSerializer(obj.GetType());
                ser.Serialize(writer, obj, ns);
                result = Encoding.UTF8.GetString(ms.ToArray());
            };

            return result;
        }


        public static T DeSerialize<T>(string str)
        {
            throw new NotImplementedException();
        }
    }
}
