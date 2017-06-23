namespace BizzDesk_Leap_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRequest : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Request",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false, precision: 0),
                        EndDate = c.DateTime(nullable: false, precision: 0),
                        EmployeeID = c.Int(nullable: false),
                        LeaveID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Employee", t => t.EmployeeID, cascadeDelete: true)
                .ForeignKey("dbo.Leave", t => t.LeaveID, cascadeDelete: true)
                .Index(t => t.EmployeeID)
                .Index(t => t.LeaveID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Request", "LeaveID", "dbo.Leave");
            DropForeignKey("dbo.Request", "EmployeeID", "dbo.Employee");
            DropIndex("dbo.Request", new[] { "LeaveID" });
            DropIndex("dbo.Request", new[] { "EmployeeID" });
            DropTable("dbo.Request");
        }
    }
}
