using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.OAuth;
using Owin;
using BizzDesk_Leap_API.DAL;

[assembly: OwinStartup(typeof(BizzDesk_Leap_API.Startup))]

namespace BizzDesk_Leap_API
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
        }
    }
}
