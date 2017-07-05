namespace BizzDesk_Leap_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        StaffID = c.Int(nullable: false, identity: true),
                        EmployeeID = c.String(nullable: false, maxLength: 12, storeType: "nvarchar"),
                        FirstName = c.String(nullable: false, unicode: false),
                        MiddleName = c.String(unicode: false),
                        LastName = c.String(nullable: false, unicode: false),
                        Gender = c.Int(nullable: false),
                        DOB = c.DateTime(nullable: false, precision: 0),
                        AppointmentDate = c.DateTime(nullable: false, precision: 0),
                        Email = c.String(nullable: false, unicode: false),
                        Address = c.String(nullable: false, unicode: false),
                        PhoneNo = c.String(nullable: false, unicode: false),
                        DepartmentID = c.Int(nullable: false),
                        RankID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StaffID)
                .ForeignKey("dbo.Department", t => t.DepartmentID, cascadeDelete: true)
                .ForeignKey("dbo.Rank", t => t.RankID, cascadeDelete: true)
                .Index(t => t.EmployeeID, unique: true)
                .Index(t => t.DepartmentID)
                .Index(t => t.RankID);

            CreateTable(
                "dbo.Request",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false, precision: 0),
                        EndDate = c.DateTime(nullable: false, precision: 0),
                        RequestDate = c.DateTime(nullable: false, precision: 0),
                        Status = c.Int(nullable: false),
                        StaffID = c.Int(nullable: false),
                        LeaveID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Employee", t => t.StaffID, cascadeDelete: true)
                .ForeignKey("dbo.Leave", t => t.LeaveID, cascadeDelete: true)
                .Index(t => t.StaffID)
                .Index(t => t.LeaveID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Request", "LeaveID", "dbo.Leave");
            DropForeignKey("dbo.Request", "StaffID", "dbo.Employee");
            DropForeignKey("dbo.Employee", "RankID", "dbo.Rank");
            DropForeignKey("dbo.Employee", "DepartmentID", "dbo.Department");
            DropIndex("dbo.Request", new[] { "LeaveID" });
            DropIndex("dbo.Request", new[] { "StaffID" });
            DropIndex("dbo.Employee", new[] { "RankID" });
            DropIndex("dbo.Employee", new[] { "DepartmentID" });
            DropIndex("dbo.Employee", new[] { "EmployeeID" });
            DropTable("dbo.Request");
            DropTable("dbo.Employee");
        }
    }
}
