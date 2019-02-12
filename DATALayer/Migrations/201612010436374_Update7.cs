namespace DATALayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update7 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Attachments", "DefectID", "dbo.Defects");
            DropForeignKey("dbo.Defects", "ProjectID", "dbo.Projects");
            DropForeignKey("dbo.Attachments", "ProjectID", "dbo.Projects");
            DropIndex("dbo.Attachments", new[] { "DefectID" });
            DropIndex("dbo.Attachments", new[] { "ProjectID" });
            DropIndex("dbo.Defects", new[] { "ProjectID" });
            AddColumn("dbo.Defects", "PriorityID", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Defects", "PriorityID");
            CreateIndex("dbo.Defects", "ProjectID");
            CreateIndex("dbo.Attachments", "ProjectID");
            CreateIndex("dbo.Attachments", "DefectID");
            AddForeignKey("dbo.Attachments", "ProjectID", "dbo.Projects", "ID");
            AddForeignKey("dbo.Defects", "ProjectID", "dbo.Projects", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Attachments", "DefectID", "dbo.Defects", "ID");
        }
    }
}
