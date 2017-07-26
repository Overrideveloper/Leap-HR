using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.OAuth;
using Owin;

[assembly: OwinStartup(typeof(BizzDesk_Leap_API.Startup))]

namespace BizzDesk_Leap_API
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var oAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/api/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                AllowInsecureHttp = true
            };
            // Enable the application to use bearer tokens to authenticate users
            app.UseOAuthBearerTokens(oAuthOptions);
        }
    }
}