namespace BizzDesk_Leap_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrate11 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Location", "Title", c => c.String(unicode: false));
            AlterColumn("dbo.Location", "Address", c => c.String(unicode: false));
            AlterColumn("dbo.Location", "LGA", c => c.String(unicode: false));
            AlterColumn("dbo.Location", "State", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Location", "State", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.Location", "LGA", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.Location", "Address", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.Location", "Title", c => c.String(nullable: false, unicode: false));
        }
    }
}
