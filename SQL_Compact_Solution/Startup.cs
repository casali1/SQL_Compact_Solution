using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SQL_Compact_Solution.Startup))]
namespace SQL_Compact_Solution
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
