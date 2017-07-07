namespace BizzDesk_Leap_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration2 : DbMigration
    {
        public override void Up()
        {
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
            DropTable("dbo.Role");
        }
    }
}
