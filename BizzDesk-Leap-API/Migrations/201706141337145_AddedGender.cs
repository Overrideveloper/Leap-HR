namespace BizzDesk_Leap_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedGender : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employee", "Gender", c => c.String(nullable: false, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employee", "Gender");
        }
    }
}
