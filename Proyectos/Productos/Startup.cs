using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Productos.Startup))]
namespace Productos
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
