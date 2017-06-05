﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using BizzDesk_Leap_API.Models;

namespace BizzDesk_Leap_API.DAL
{
    public class LeapDB: DbContext
    {
        public LeapDB() : base("Leap")
        {
            Database.SetInitializer<LeapDB>(new DBInitializer());
        }

        public DbSet <Department> Department { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}