using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StackExchange.Redis;


namespace Evol.Redis.Test
{
    [TestClass]
    public class BasicTest
    {
        [TestMethod]
        public void ConnectTest()
        {
            var redis = ConnectionMultiplexer.Connect("localhost");
            Assert.IsTrue(redis.IsConnected);
            redis.Close();
        }

        [TestMethod]
        public void DatabaseTest()
        {
            var redis = ConnectionMultiplexer.Connect("localhost");
            Assert.IsTrue(redis.IsConnected);

            var db = redis.GetDatabase();
            var key = "key1";
            var value = "12345678";

            db.KeyDelete(key);
           
            var success = db.StringSet(key, value);
            var value2 = db.StringGet(key);
            Assert.IsTrue(value == value2);

            redis.Close();
        }

        [TestMethod]
        public void DeleteTest()
        {
            var redis = ConnectionMultiplexer.Connect("localhost");
            Assert.IsTrue(redis.IsConnected);

            var db = redis.GetDatabase();

            var success = db.KeyDelete("1");
            var success2 = db.KeyDelete("2");

            redis.Close();
        }

        public void BitSetTest()
        {
            var redis = ConnectionMultiplexer.Connect("localhost");
            Assert.IsTrue(redis.IsConnected);
            var db = redis.GetDatabase();
            db.StringGetBit((RedisKey)"", 1);

        }


    }
}
