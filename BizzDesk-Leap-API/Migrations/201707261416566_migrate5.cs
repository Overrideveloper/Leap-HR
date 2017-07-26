namespace BizzDesk_Leap_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrate5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employee", "LocationID", c => c.Int());
            CreateIndex("dbo.Employee", "LocationID");
            AddForeignKey("dbo.Employee", "LocationID", "dbo.Location", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employee", "LocationID", "dbo.Location");
            DropIndex("dbo.Employee", new[] { "LocationID" });
            DropColumn("dbo.Employee", "LocationID");
        }
    }
}
