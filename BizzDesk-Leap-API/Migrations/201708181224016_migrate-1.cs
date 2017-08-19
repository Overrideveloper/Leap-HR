namespace BizzDesk_Leap_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrate1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.Location",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Title = c.String(unicode: false),
                    Address = c.String(unicode: false),
                    LGA = c.String(unicode: false),
                    State = c.String(unicode: false),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.Rank",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    DepartmentID = c.Int(nullable: false),
                    Title = c.String(nullable: false, unicode: false),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Department", t => t.DepartmentID, cascadeDelete: true)
                .Index(t => t.DepartmentID);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EmployeeNumber = c.String(nullable: false, maxLength: 12, storeType: "nvarchar"),
                        FirstName = c.String(nullable: false, unicode: false),
                        MiddleName = c.String(unicode: false),
                        LastName = c.String(nullable: false, unicode: false),
                        Gender = c.String(nullable: false, unicode: false),
                        DOB = c.DateTime(nullable: false, precision: 0),
                        AppointmentDate = c.DateTime(nullable: false, precision: 0),
                        Email = c.String(nullable: false, unicode: false),
                        PhoneNo = c.String(nullable: false, unicode: false),
                        DepartmentID = c.Int(nullable: false),
                        RankID = c.Int(nullable: false),
                        LocationID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Department", t => t.DepartmentID, cascadeDelete: true)
                .ForeignKey("dbo.Location", t => t.LocationID)
                .ForeignKey("dbo.Rank", t => t.RankID, cascadeDelete: true)
                .Index(t => t.EmployeeNumber, unique: true)
                .Index(t => t.DepartmentID)
                .Index(t => t.RankID)
                .Index(t => t.LocationID);

            CreateTable(
                "dbo.LeaveType",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Title = c.String(nullable: false, unicode: false),
                    GenderConstraint = c.String(unicode: false),
                })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Leave",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, unicode: false),
                        LeaveTypeID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.LeaveType", t => t.LeaveTypeID)
                .Index(t => t.LeaveTypeID);
            
            
            CreateTable(
                "dbo.Request",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false, precision: 0),
                        EndDate = c.DateTime(nullable: false, precision: 0),
                        RequestDate = c.DateTime(nullable: false, precision: 0),
                        Status = c.Int(nullable: false),
                        EmployeeID = c.Int(nullable: false),
                        LeaveID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Employee", t => t.EmployeeID, cascadeDelete: true)
                .ForeignKey("dbo.Leave", t => t.LeaveID, cascadeDelete: true)
                .Index(t => t.EmployeeID)
                .Index(t => t.LeaveID);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, unicode: false),
                        CanManageDepartments = c.Boolean(nullable: false),
                        CanManageRanks = c.Boolean(nullable: false),
                        CanManageEmployees = c.Boolean(nullable: false),
                        CanManageLeaves = c.Boolean(nullable: false),
                        CanManageRequests = c.Boolean(nullable: false),
                        CanManageRoles = c.Boolean(nullable: false),
                        CanManageUsers = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Request", "LeaveID", "dbo.Leave");
            DropForeignKey("dbo.Request", "EmployeeID", "dbo.Employee");
            DropForeignKey("dbo.Leave", "LeaveTypeID", "dbo.LeaveType");
            DropForeignKey("dbo.Employee", "RankID", "dbo.Rank");
            DropForeignKey("dbo.Rank", "DepartmentID", "dbo.Department");
            DropForeignKey("dbo.Employee", "LocationID", "dbo.Location");
            DropForeignKey("dbo.Employee", "DepartmentID", "dbo.Department");
            DropIndex("dbo.Request", new[] { "LeaveID" });
            DropIndex("dbo.Request", new[] { "EmployeeID" });
            DropIndex("dbo.Leave", new[] { "LeaveTypeID" });
            DropIndex("dbo.Rank", new[] { "DepartmentID" });
            DropIndex("dbo.Employee", new[] { "LocationID" });
            DropIndex("dbo.Employee", new[] { "RankID" });
            DropIndex("dbo.Employee", new[] { "DepartmentID" });
            DropIndex("dbo.Employee", new[] { "EmployeeNumber" });
            DropTable("dbo.Role");
            DropTable("dbo.Request");
            DropTable("dbo.LeaveType");
            DropTable("dbo.Leave");
            DropTable("dbo.Rank");
            DropTable("dbo.Location");
            DropTable("dbo.Employee");
            DropTable("dbo.Department");
        }
    }
}
