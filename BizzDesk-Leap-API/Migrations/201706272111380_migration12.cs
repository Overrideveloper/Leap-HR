namespace BizzDesk_Leap_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration12 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Request", "RequestDate", c => c.DateTime(nullable: false, precision: 0));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Request", "RequestDate");
        }
    }
}
