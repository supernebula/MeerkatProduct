using System;
using System.Text;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nebula.EntityFramework.Repository.Test.Core;
using Nebula.EntityFramework.Repository.Test.Entities;
using Nebula.EntityFramework.Repository.Test.Repositories;

namespace Nebula.EntityFramework.Repository.Test
{
    /// <summary>
    /// UnitOfWorkTest 的摘要说明
    /// </summary>
    [TestClass]
    public class UnitOfWorkTest
    {
        public IUnitOfWork UnitOfWorkObj;

        [ThreadStatic]
        private static IDbContextFactory<FakeEcDbContext> _dbContextFactory;

        [TestInitialize]
        public void Init()
        {
            _dbContextFactory = new FakeEfDbContextFactory<FakeEcDbContext>();
        }

        [TestMethod,Description("EntityFramework工作单元的核心在于：针对数据库的多个更新逻辑从开始到结束（提交到数据库），使用同一个DbContext")]
        public void MuiltChangeTest()
        {
            var unitOfWorkObj = new UnitOfWork<FakeEcDbContext>() { DbContextFactory = _dbContextFactory };
            var orderRepo = new FakeOrderRepository()  {  DbContextFactory = _dbContextFactory };
            var productRepo = new FakeProductRepository() { DbContextFactory = _dbContextFactory };
            var userRepo = new FakeUserRepository() { DbContextFactory = _dbContextFactory };

            unitOfWorkObj.BeginTransaction();
            try
            {
                orderRepo.Insert(new FakeOrder());
                productRepo.Insert(new FakeProduct());
                userRepo.Insert(new FakeUser());
                unitOfWorkObj.Commit();
            }
            catch (Exception ex)
            {
                unitOfWorkObj.RollBack();
            }
            finally
            {
                unitOfWorkObj.Dispose();
            }
        }


        #region template

        private TestContext _testContextInstance;

        /// <summary>
        ///获取或设置测试上下文，该上下文提供
        ///有关当前测试运行及其功能的信息。
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return _testContextInstance;
            }
            set
            {
                _testContextInstance = value;
            }
        }

        #region 附加测试特性
        //
        // 编写测试时，可以使用以下附加特性: 
        //
        // 在运行类中的第一个测试之前使用 ClassInitialize 运行代码
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // 在类中的所有测试都已运行之后使用 ClassCleanup 运行代码
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // 在运行每个测试之前，使用 TestInitialize 来运行代码
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // 在每个测试运行完之后，使用 TestCleanup 来运行代码
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        #endregion
    }
}
