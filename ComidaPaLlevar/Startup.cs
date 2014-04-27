using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ComidaPaLlevar.Startup))]
namespace ComidaPaLlevar
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
