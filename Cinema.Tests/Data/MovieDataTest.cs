using Microsoft.VisualStudio.TestTools.UnitTesting;
using Evol.Cinema.Domain.QueryEntries;
using Evol.Cinema.Domain.Repositories;
using Evol.Domain;
using Microsoft.Practices.Unity;
using System.Diagnostics;
using Evol.Cinema.Data.Repositories;
using Evol.Common.Repository;
using Evol.Domain.Messaging;
using Evol.EntityFramework.Repository;

namespace Cinema.Tests.Data
{
    [TestClass]
    public class MovieDataTest
    {
        public static IMovieQueryEntry MovieQueryEntry { get; set; }

        public static IMovieRepository MovieRepository { get; set; }

        public static IActiveUnitOfWork ActiveUnitOfWork { get; set; }

        public static IUnitOfWork UnitOfWork { get; set; }

        public static ICommandBus CommandBus { get; set; }

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            AppStart.Init();
            MovieQueryEntry = AppConfiguration.Current.Container.Resolve<IMovieQueryEntry>();
            MovieRepository = AppConfiguration.Current.Container.Resolve<IMovieRepository>();
            ActiveUnitOfWork = AppConfiguration.Current.Container.Resolve<IActiveUnitOfWork>();
            UnitOfWork = AppConfiguration.Current.Container.Resolve<IUnitOfWork>();
            CommandBus = AppConfiguration.Current.Container.Resolve<ICommandBus>();
        }

        [TestInitialize]
        public void MethodInit()
        {

        }

        [TestMethod]
        public void TestMethod1()
        {
            Trace.WriteLine("MovieQueryEntry:" + MovieQueryEntry.GetType().FullName);
            Trace.WriteLine("MovieRepository:" + MovieRepository.GetType().FullName);
            Trace.WriteLine("CommandBus:" + CommandBus.GetType().FullName);
            Trace.WriteLine("IActiveUnitOfWork = IUnitOfWork :" + (ActiveUnitOfWork == UnitOfWork));
        }
    }
}
