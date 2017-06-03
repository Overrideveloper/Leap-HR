using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BizzDesk_Leap_API.DAL
{
    public class DBInitializer: CreateDatabaseIfNotExists<LeapDB>
    {
        protected override void Seed(LeapDB context)
        {
            base.Seed(context);
        }
    }
}