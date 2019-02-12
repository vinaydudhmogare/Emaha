namespace DATALayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Defects", "Title", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Defects", "Title");
        }
    }
}
