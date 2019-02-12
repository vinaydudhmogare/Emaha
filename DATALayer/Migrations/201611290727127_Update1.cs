namespace DATALayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attachments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DefectID = c.Int(),
                        OrignalFileName = c.String(),
                        FileName = c.String(),
                        Size = c.String(),
                        FilePath = c.String(),
                        ProjectID = c.Int(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Defects", t => t.DefectID)
                .ForeignKey("dbo.Projects", t => t.ProjectID)
                .Index(t => t.DefectID)
                .Index(t => t.ProjectID);
            
            CreateTable(
                "dbo.Defects",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SmallDescription = c.String(),
                        LongDescription = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        ExpireyDate = c.DateTime(nullable: false),
                        StatusID = c.Int(),
                        ProjectID = c.Int(nullable: false),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Projects", t => t.ProjectID, cascadeDelete: true)
                .Index(t => t.ProjectID);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProjectID = c.String(),
                        Title = c.String(),
                        SmallDescription = c.String(),
                        LongDescription = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        ParentProjectID = c.String(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.DefectStatus",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attachments", "ProjectID", "dbo.Projects");
            DropForeignKey("dbo.Defects", "ProjectID", "dbo.Projects");
            DropForeignKey("dbo.Attachments", "DefectID", "dbo.Defects");
            DropIndex("dbo.Defects", new[] { "ProjectID" });
            DropIndex("dbo.Attachments", new[] { "ProjectID" });
            DropIndex("dbo.Attachments", new[] { "DefectID" });
            DropTable("dbo.DefectStatus");
            DropTable("dbo.Projects");
            DropTable("dbo.Defects");
            DropTable("dbo.Attachments");
        }
    }
}
