namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migr2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Receptions", "Id", "dbo.Notes");
            DropIndex("dbo.Receptions", new[] { "Id" });
            DropPrimaryKey("dbo.Receptions");
            DropPrimaryKey("dbo.Notes");
            AlterColumn("dbo.Receptions", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Notes", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Receptions", "Id");
            AddPrimaryKey("dbo.Notes", "Id");
            CreateIndex("dbo.Notes", "Id");
            AddForeignKey("dbo.Notes", "Id", "dbo.Receptions", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notes", "Id", "dbo.Receptions");
            DropIndex("dbo.Notes", new[] { "Id" });
            DropPrimaryKey("dbo.Notes");
            DropPrimaryKey("dbo.Receptions");
            AlterColumn("dbo.Notes", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Receptions", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Notes", "Id");
            AddPrimaryKey("dbo.Receptions", "Id");
            CreateIndex("dbo.Receptions", "Id");
            AddForeignKey("dbo.Receptions", "Id", "dbo.Notes", "Id");
        }
    }
}
