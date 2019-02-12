namespace DATALayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Projects", "ParentProjectID", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Projects", "ParentProjectID", c => c.String());
        }
    }
}
