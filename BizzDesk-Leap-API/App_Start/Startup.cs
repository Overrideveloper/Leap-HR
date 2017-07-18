using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using BizzDesk_Leap_API.Security;
using Microsoft.Owin.Security.OAuth;


[assembly: OwinStartup(typeof(BizzDesk_Leap_API.App_Start.Startup))]
namespace BizzDesk_Leap_API.App_Start
{

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            app.CreatePerOwinContext(ApplicationUserDBContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);

            var oAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/api/token"),
                Provider = new ApplicationOAuthProvider(),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                AllowInsecureHttp = true
            };

            //enable use of beare tokens to authenticate users
            app.UseOAuthBearerTokens(oAuthOptions);
        }
    }
}