namespace BizzDesk_Leap_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrate3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Employee", "Address");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employee", "Address", c => c.String(nullable: false, unicode: false));
        }
    }
}
