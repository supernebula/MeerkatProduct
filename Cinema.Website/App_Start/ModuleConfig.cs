
namespace Cinema.Website
{
    public static class ModuleConfig
    {
        public static void RegisterModules()
        {
            (new CinemaWebsiteModule()).Initailize();
        }
    }
}