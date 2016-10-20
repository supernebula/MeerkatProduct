using Evol.Cinema.Data;
using Evol.Cinema.Domain;
using Evol.Domain.Modules;

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