using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BizzDesk_Leap_Client.Startup))]
namespace BizzDesk_Leap_Client
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
