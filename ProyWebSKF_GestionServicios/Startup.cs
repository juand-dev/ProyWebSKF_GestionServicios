using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProyWebSKF_GestionServicios.Startup))]
namespace ProyWebSKF_GestionServicios
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
