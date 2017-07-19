using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace BizzDesk_Leap_API.Security
{
    public class ApplicationUserDBContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationUserDBContext() : base("Leap") {
            Database.SetInitializer<ApplicationUserDBContext>(new ApplicationUserDbInitializer());
        }

        public static ApplicationUserDBContext Create()
        {
            return new ApplicationUserDBContext();
        }

    }
}