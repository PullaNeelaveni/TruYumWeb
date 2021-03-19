namespace TruYumWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MenuItem", "Category_Id", "dbo.Category");
            DropIndex("dbo.MenuItem", new[] { "Category_Id" });
            DropColumn("dbo.MenuItem", "CategoryId");
            RenameColumn(table: "dbo.MenuItem", name: "Category_Id", newName: "CategoryId");
            DropPrimaryKey("dbo.Category");
            AlterColumn("dbo.MenuItem", "CategoryId", c => c.Int(nullable: false));
            AlterColumn("dbo.Category", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Category", "Id");
            CreateIndex("dbo.MenuItem", "CategoryId");
            AddForeignKey("dbo.MenuItem", "CategoryId", "dbo.Category", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MenuItem", "CategoryId", "dbo.Category");
            DropIndex("dbo.MenuItem", new[] { "CategoryId" });
            DropPrimaryKey("dbo.Category");
            AlterColumn("dbo.Category", "Id", c => c.Byte(nullable: false));
            AlterColumn("dbo.MenuItem", "CategoryId", c => c.Byte());
            AddPrimaryKey("dbo.Category", "Id");
            RenameColumn(table: "dbo.MenuItem", name: "CategoryId", newName: "Category_Id");
            AddColumn("dbo.MenuItem", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.MenuItem", "Category_Id");
            AddForeignKey("dbo.MenuItem", "Category_Id", "dbo.Category", "Id");
        }
    }
}
