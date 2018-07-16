namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migr2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Notes", "DiseaseId", "dbo.Diseases");
            DropForeignKey("dbo.Notes", "DiseaseHistoryId", "dbo.DiseaseHistories");
            DropForeignKey("dbo.Receptions", "Id", "dbo.Notes");
            DropIndex("dbo.Receptions", new[] { "Id" });
            DropIndex("dbo.Notes", new[] { "DiseaseId" });
            DropIndex("dbo.Notes", new[] { "DiseaseHistoryId" });
            DropPrimaryKey("dbo.Receptions");
            DropPrimaryKey("dbo.Notes");
            AlterColumn("dbo.Receptions", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Receptions", "NoteId", c => c.Int());
            AlterColumn("dbo.Notes", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Notes", "ReceptionId", c => c.Int());
            AlterColumn("dbo.Notes", "DiseaseId", c => c.Int());
            AlterColumn("dbo.Notes", "DiseaseHistoryId", c => c.Int());
            AddPrimaryKey("dbo.Receptions", "Id");
            AddPrimaryKey("dbo.Notes", "Id");
            CreateIndex("dbo.Notes", "Id");
            CreateIndex("dbo.Notes", "DiseaseId");
            CreateIndex("dbo.Notes", "DiseaseHistoryId");
            AddForeignKey("dbo.Notes", "DiseaseId", "dbo.Diseases", "Id");
            AddForeignKey("dbo.Notes", "DiseaseHistoryId", "dbo.DiseaseHistories", "Id");
            AddForeignKey("dbo.Notes", "Id", "dbo.Receptions", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notes", "Id", "dbo.Receptions");
            DropForeignKey("dbo.Notes", "DiseaseHistoryId", "dbo.DiseaseHistories");
            DropForeignKey("dbo.Notes", "DiseaseId", "dbo.Diseases");
            DropIndex("dbo.Notes", new[] { "DiseaseHistoryId" });
            DropIndex("dbo.Notes", new[] { "DiseaseId" });
            DropIndex("dbo.Notes", new[] { "Id" });
            DropPrimaryKey("dbo.Notes");
            DropPrimaryKey("dbo.Receptions");
            AlterColumn("dbo.Notes", "DiseaseHistoryId", c => c.Int(nullable: false));
            AlterColumn("dbo.Notes", "DiseaseId", c => c.Int(nullable: false));
            AlterColumn("dbo.Notes", "ReceptionId", c => c.Int(nullable: false));
            AlterColumn("dbo.Notes", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Receptions", "NoteId", c => c.Int(nullable: false));
            AlterColumn("dbo.Receptions", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Notes", "Id");
            AddPrimaryKey("dbo.Receptions", "Id");
            CreateIndex("dbo.Notes", "DiseaseHistoryId");
            CreateIndex("dbo.Notes", "DiseaseId");
            CreateIndex("dbo.Receptions", "Id");
            AddForeignKey("dbo.Receptions", "Id", "dbo.Notes", "Id");
            AddForeignKey("dbo.Notes", "DiseaseHistoryId", "dbo.DiseaseHistories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Notes", "DiseaseId", "dbo.Diseases", "Id", cascadeDelete: true);
        }
    }
}
