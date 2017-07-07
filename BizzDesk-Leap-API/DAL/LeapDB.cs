using System;
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

        public DbSet<Department> Department { get; set; }
        public DbSet<Rank> Rank { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Leave> Leave { get; set; }
        public DbSet<Request> Request { get; set; }
        public DbSet<Role> Role { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}