namespace BizzDesk_Leap_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrate2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employee", "user_id", c => c.String(nullable: false, maxLength: 24, storeType: "nvarchar"));
            AlterColumn("dbo.Employee", "EmployeeNumber", c => c.String(nullable: false, maxLength: 24, storeType: "nvarchar"));
            CreateIndex("dbo.Employee", "user_id", unique: true);
            CreateIndex("dbo.Employee", "EmployeeNumber", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Employee", new[] { "EmployeeNumber" });
            DropIndex("dbo.Employee", new[] { "user_id" });
            AlterColumn("dbo.Employee", "EmployeeNumber", c => c.String(nullable: false, maxLength: 12, storeType: "nvarchar"));
            DropColumn("dbo.Employee", "user_id");
        }
    }
}
