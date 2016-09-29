namespace MvcEssentials.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.NewsArticles", "ImageId", "dbo.Images");
            DropForeignKey("dbo.Images", "NewsArticle_Id", "dbo.NewsArticles");
            DropIndex("dbo.NewsArticles", new[] { "ImageId" });
            DropIndex("dbo.Images", new[] { "NewsArticleId" });
            DropIndex("dbo.Images", new[] { "NewsArticle_Id" });
            DropColumn("dbo.Images", "NewsArticleId");
            RenameColumn(table: "dbo.Images", name: "NewsArticle_Id", newName: "NewsArticleId");
            AlterColumn("dbo.Images", "NewsArticleId", c => c.Int(nullable: false));
            CreateIndex("dbo.Images", "NewsArticleId");
            AddForeignKey("dbo.Images", "NewsArticleId", "dbo.NewsArticles", "Id", cascadeDelete: true);
            DropColumn("dbo.NewsArticles", "ImageId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.NewsArticles", "ImageId", c => c.Int());
            DropForeignKey("dbo.Images", "NewsArticleId", "dbo.NewsArticles");
            DropIndex("dbo.Images", new[] { "NewsArticleId" });
            AlterColumn("dbo.Images", "NewsArticleId", c => c.Int());
            RenameColumn(table: "dbo.Images", name: "NewsArticleId", newName: "NewsArticle_Id");
            AddColumn("dbo.Images", "NewsArticleId", c => c.Int(nullable: false));
            CreateIndex("dbo.Images", "NewsArticle_Id");
            CreateIndex("dbo.Images", "NewsArticleId");
            CreateIndex("dbo.NewsArticles", "ImageId");
            AddForeignKey("dbo.Images", "NewsArticle_Id", "dbo.NewsArticles", "Id");
            AddForeignKey("dbo.NewsArticles", "ImageId", "dbo.Images", "Id");
        }
    }
}
