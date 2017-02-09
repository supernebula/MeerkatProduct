using System;
using Evol.MongoDB.Repository;
using Evol.MongoDB.Test.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Evol.MongoDB.Test
{
    [TestClass]
    public class FunctionTest
    {
        private static OrderRepository orderRepository;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {

            orderRepository = new OrderRepository(new DefaultMongoDbContextFactory());
        }

        [TestMethod]
        public void AddOneTest()
        {
            var item = new Order()
            {
                Id = Guid.NewGuid().ToString(),
                Receiver = "王五",
                Address = "文一路500号",
                Amount = 120.6m,
                CreateTime = DateTime.Now
            };

            orderRepository.AddAsync(item);
        }
    }
}
