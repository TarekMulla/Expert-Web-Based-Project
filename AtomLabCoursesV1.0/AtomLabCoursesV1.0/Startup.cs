using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AtomLabCoursesV1._0.Startup))]
namespace AtomLabCoursesV1._0
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
