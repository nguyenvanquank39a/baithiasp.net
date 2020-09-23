using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SInhVien.Startup))]
namespace SInhVien
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
