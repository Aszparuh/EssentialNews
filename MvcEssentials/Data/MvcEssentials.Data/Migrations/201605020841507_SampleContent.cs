namespace MvcEssentials.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SampleContent : DbMigration
    {
        public override void Up()
        {
            this.AddColumn("dbo.NewsArticles", "SampleContent", c => c.String(nullable: false, maxLength: 1000));
        }

        public override void Down()
        {
            this.DropColumn("dbo.NewsArticles", "SampleContent");
        }
    }
}
