using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BoardgameCollectionWebsite.Startup))]
namespace BoardgameCollectionWebsite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
