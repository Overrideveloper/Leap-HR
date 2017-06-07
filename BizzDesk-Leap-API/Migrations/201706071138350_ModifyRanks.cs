namespace BizzDesk_Leap_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyRanks : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Rank", "Title", c => c.String(nullable: false, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Rank", "Title", c => c.Int(nullable: false));
        }
    }
}
