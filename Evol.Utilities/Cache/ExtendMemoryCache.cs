using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;

namespace Evol.Utilities.Cache
{
    public class ExtendMemoryCache
    {
        public static MemoryCache Cache = MemoryCache.Default;

        public static bool Add<T>(string key, T obj)
        {
            throw new NotImplementedException();
        }

        public static bool AddOrGetExisting<T>(string key, T obj)
        {
            throw new NotImplementedException();
        }

        public static T Get<T>(string key)
        {
            throw new NotImplementedException();
        }

        public static bool IsExsit(string key)
        {
            throw new NotImplementedException();
        }


        public static T Remove<T>(string key)
        {
            throw new NotImplementedException();
        }

        public static void Set<T>(string key)
        {
            throw new NotImplementedException();
        }

        //...
    }


}
