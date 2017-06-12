namespace BizzDesk_Leap_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditEmployee2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employee", "EmployeeID", c => c.String(nullable: false, maxLength: 12, storeType: "nvarchar"));
            CreateIndex("dbo.Employee", "EmployeeID", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Employee", new[] { "EmployeeID" });
            DropColumn("dbo.Employee", "EmployeeID");
        }
    }
}
