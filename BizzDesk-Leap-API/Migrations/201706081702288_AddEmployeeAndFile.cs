namespace BizzDesk_Leap_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmployeeAndFile : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, unicode: false),
                        MiddleName = c.String(unicode: false),
                        LastName = c.String(nullable: false, unicode: false),
                        DOB = c.DateTime(nullable: false, precision: 0),
                        AppointmentDate = c.DateTime(nullable: false, precision: 0),
                        Email = c.String(nullable: false, unicode: false),
                        Address = c.String(nullable: false, unicode: false),
                        PhoneNo = c.String(nullable: false, unicode: false),
                        DepartmentID = c.Int(nullable: false),
                        RankID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Department", t => t.DepartmentID, cascadeDelete: true)
                .ForeignKey("dbo.Rank", t => t.RankID, cascadeDelete: true)
                .Index(t => t.ID, unique: true)
                .Index(t => t.DepartmentID)
                .Index(t => t.RankID);
            
            CreateTable(
                "dbo.File",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 255, storeType: "nvarchar"),
                        ContentType = c.String(maxLength: 100, storeType: "nvarchar"),
                        Content = c.Binary(),
                        FileType = c.Int(nullable: false),
                        EmployeeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Employee", t => t.EmployeeID, cascadeDelete: true)
                .Index(t => t.EmployeeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.File", "EmployeeID", "dbo.Employee");
            DropForeignKey("dbo.Employee", "RankID", "dbo.Rank");
            DropForeignKey("dbo.Employee", "DepartmentID", "dbo.Department");
            DropIndex("dbo.File", new[] { "EmployeeID" });
            DropIndex("dbo.Employee", new[] { "RankID" });
            DropIndex("dbo.Employee", new[] { "DepartmentID" });
            DropIndex("dbo.Employee", new[] { "ID" });
            DropTable("dbo.File");
            DropTable("dbo.Employee");
        }
    }
}
