using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DBoardPetFan.WEB.Startup))]
namespace DBoardPetFan.WEB
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
