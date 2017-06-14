namespace BizzDesk_Leap_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedGender : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employee", "Gender", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employee", "Gender", c => c.String(nullable: false, unicode: false));
        }
    }
}