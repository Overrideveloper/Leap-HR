namespace BizzDesk_Leap_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrate10 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employee", "LocationID", "dbo.Location");
            DropIndex("dbo.Employee", new[] { "LocationID" });
            AlterColumn("dbo.Employee", "LocationID", c => c.Int(nullable: false));
            CreateIndex("dbo.Employee", "LocationID");
            AddForeignKey("dbo.Employee", "LocationID", "dbo.Location", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employee", "LocationID", "dbo.Location");
            DropIndex("dbo.Employee", new[] { "LocationID" });
            AlterColumn("dbo.Employee", "LocationID", c => c.Int());
            CreateIndex("dbo.Employee", "LocationID");
            AddForeignKey("dbo.Employee", "LocationID", "dbo.Location", "ID");
        }
    }
}
