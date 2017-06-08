namespace BizzDesk_Leap_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedFile : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.File", newName: "Files");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Files", newName: "File");
        }
    }
}
