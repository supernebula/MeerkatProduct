﻿using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Nebula.Utilities.Serialization
{
    public class JsonUtility
    {
        public static string Serialize(object value)
        {
            try
            {
                var output = Newtonsoft.Json.JsonConvert.SerializeObject(value);
                return output;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static T Deserialize<T>(string str)
        {
            try
            {
                var value = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(str);
                return value;
            }
            catch (Exception)
            {
                return default(T);
            }
        }

        public static string SerializeByDataContract(object value)
        {
            var serializer = new DataContractJsonSerializer(value.GetType());
            using (MemoryStream ms = new MemoryStream())
            {
                serializer.WriteObject(ms, value);
                var str = Encoding.UTF8.GetString(ms.ToArray());
                return str;
            }
        }

        public static T DeserializeByDataContract<T>(string str)
        {
            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(str)))
            {
                var serializer = new DataContractJsonSerializer(typeof(T));
                var value = (T)serializer.ReadObject(ms);
                return value;
            }
        }
    }
}
