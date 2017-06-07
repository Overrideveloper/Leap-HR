namespace BizzDesk_Leap_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRanks : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rank",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DepartmentID = c.Int(nullable: false),
                        Title = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Department", t => t.DepartmentID, cascadeDelete: true)
                .Index(t => t.DepartmentID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rank", "DepartmentID", "dbo.Department");
            DropIndex("dbo.Rank", new[] { "DepartmentID" });
            DropTable("dbo.Rank");
            DropTable("dbo.Department");
        }
    }
}
