namespace BizzDesk_Leap_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrate7 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LeaveType",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, unicode: false),
                        GenderConstraint = c.String(unicode: false),
                        DepartmentID = c.Int(),
                        RankID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Department", t => t.DepartmentID)
                .ForeignKey("dbo.Rank", t => t.RankID)
                .Index(t => t.DepartmentID)
                .Index(t => t.RankID);
            
            DropColumn("dbo.Leave", "LeaveType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Leave", "LeaveType", c => c.Int(nullable: false));
            DropForeignKey("dbo.LeaveType", "RankID", "dbo.Rank");
            DropForeignKey("dbo.LeaveType", "DepartmentID", "dbo.Department");
            DropIndex("dbo.LeaveType", new[] { "RankID" });
            DropIndex("dbo.LeaveType", new[] { "DepartmentID" });
            DropTable("dbo.LeaveType");
        }
    }
}
