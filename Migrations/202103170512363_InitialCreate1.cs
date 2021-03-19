namespace TruYumWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MenuItem", "CategoryId", "dbo.Category");
            DropIndex("dbo.MenuItem", new[] { "CategoryId" });
            AddColumn("dbo.MenuItem", "Category_Id", c => c.Byte());
            AlterColumn("dbo.MenuItem", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.MenuItem", "Category_Id");
            AddForeignKey("dbo.MenuItem", "Category_Id", "dbo.Category", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MenuItem", "Category_Id", "dbo.Category");
            DropIndex("dbo.MenuItem", new[] { "Category_Id" });
            AlterColumn("dbo.MenuItem", "CategoryId", c => c.Byte(nullable: false));
            DropColumn("dbo.MenuItem", "Category_Id");
            CreateIndex("dbo.MenuItem", "CategoryId");
            AddForeignKey("dbo.MenuItem", "CategoryId", "dbo.Category", "Id", cascadeDelete: true);
        }
    }
}
