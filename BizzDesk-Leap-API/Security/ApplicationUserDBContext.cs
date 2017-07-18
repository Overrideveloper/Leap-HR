using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BizzDesk_Leap_API.Security
{
    public class ApplicationUserDBContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationUserDBContext() : base("Leap") { }

        public static ApplicationUserDBContext Create()
        {
            return new ApplicationUserDBContext();
        }
    }
}