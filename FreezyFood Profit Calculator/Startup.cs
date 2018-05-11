using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FreezyFood_Profit_Calculator.Startup))]
namespace FreezyFood_Profit_Calculator
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
