namespace BizzDesk_Leap_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrate8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Leave", "LeaveTypeID", c => c.Int());
            CreateIndex("dbo.Leave", "LeaveTypeID");
            AddForeignKey("dbo.Leave", "LeaveTypeID", "dbo.LeaveType", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Leave", "LeaveTypeID", "dbo.LeaveType");
            DropIndex("dbo.Leave", new[] { "LeaveTypeID" });
            DropColumn("dbo.Leave", "LeaveTypeID");
        }
    }
}
