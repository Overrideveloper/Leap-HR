namespace BizzDesk_Leap_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrate4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Location",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, unicode: false),
                        Address = c.String(nullable: false, unicode: false),
                        LGA = c.String(nullable: false, unicode: false),
                        State = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Location");
        }
    }
}
