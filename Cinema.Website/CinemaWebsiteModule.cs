using Nebula.Cinema.Data;
using Nebula.Cinema.Domain;
using Nebula.Domain.Modules;

namespace Cinema.Website
{
    [DependOn(typeof(CinemaDataModule), typeof(CinemaDomainModule))]
    public class CinemaWebsiteModule : AppModule
    {
        public override void Initailize()
        {
            InitDependModule<CinemaWebsiteModule>();
            base.Initailize();
        }
    }
}