using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace Nebula.Utilities.Convert
{
    public static class DictionaryObjectConvert
    {
        /// <summary>
        /// 对象契约转排序字典
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static SortedDictionary<string, string> DictionarySimpleContractConvert(object obj)
        {
            var dic = new SortedDictionary<string, string>();
            var propertiesps = TypeDescriptor.GetProperties(obj.GetType());

            foreach (PropertyDescriptor prop in propertiesps)
            {
                var value = prop.GetValue(obj);
                DataMemberAttribute attr = (DataMemberAttribute)prop.Attributes[typeof(DataMemberAttribute)];
                dic.Add(attr == null ? prop.Name : attr.Name, value == null ? String.Empty : value.ToString());
            }
            return dic;
        }
    }
}
