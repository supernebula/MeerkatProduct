using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nebula.Cinema.Domain.QueryEntries;
using Nebula.Cinema.Domain.Repositories;
using Nebula.Domain;
using Microsoft.Practices.Unity;
using System.Diagnostics;
using Nebula.Cinema.Data.Repositories;

namespace Cinema.Tests.Data
{
    [TestClass]
    public class MovieDataTest
    {
        public static IMovieQueryEntry MovieQueryEntry { get; set; }

        public static IMovieRepository MovieRepository { get; set; }

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            AppStart.Init();
            MovieQueryEntry = AppConfiguration.Current.Container.Resolve<IMovieQueryEntry>();
            MovieRepository = AppConfiguration.Current.Container.Resolve<IMovieRepository>();
        }

        [TestInitialize]
        public void MethodInit()
        {

        }

        [TestMethod]
        public void TestMethod1()
        {
            Trace.WriteLine("MovieQueryEntry" + MovieQueryEntry.GetType().FullName);
            Trace.WriteLine("MovieRepository" + MovieRepository.GetType().FullName);
        }
    }
}
