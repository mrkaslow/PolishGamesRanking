using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PolishGamesRanking.Startup))]
namespace PolishGamesRanking
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
