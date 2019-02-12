namespace DATALayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "TimeZone", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projects", "TimeZone");
        }
    }
}
