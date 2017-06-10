namespace BizzDesk_Leap_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Refresh : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Department", "Title", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.Employee", "FirstName", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.Employee", "MiddleName", c => c.String(unicode: false));
            AlterColumn("dbo.Employee", "LastName", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.Employee", "DOB", c => c.DateTime(nullable: false, precision: 0));
            AlterColumn("dbo.Employee", "AppointmentDate", c => c.DateTime(nullable: false, precision: 0));
            AlterColumn("dbo.Employee", "Email", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.Employee", "Address", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.Employee", "PhoneNo", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.Rank", "Title", c => c.String(nullable: false, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Rank", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Employee", "PhoneNo", c => c.String(nullable: false));
            AlterColumn("dbo.Employee", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.Employee", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Employee", "AppointmentDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Employee", "DOB", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Employee", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Employee", "MiddleName", c => c.String());
            AlterColumn("dbo.Employee", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Department", "Title", c => c.String(nullable: false));
        }
    }
}
