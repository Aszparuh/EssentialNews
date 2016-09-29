namespace MvcEssentials.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            this.CreateTable(
                "dbo.NewsCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsDeleted);

            this.CreateTable(
                "dbo.NewsArticles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 300),
                        Content = c.String(nullable: false, maxLength: 3000),
                        IsTop = c.Boolean(),
                        NewsCategoryId = c.Int(),
                        RegionId = c.Int(),
                        ApplicationUserId = c.String(maxLength: 128),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .ForeignKey("dbo.NewsCategories", t => t.NewsCategoryId)
                .ForeignKey("dbo.Regions", t => t.RegionId)
                .Index(t => t.NewsCategoryId)
                .Index(t => t.RegionId)
                .Index(t => t.ApplicationUserId)
                .Index(t => t.IsDeleted);

            this.CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");

            this.CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);

            this.CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);

            this.CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);

            this.CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 255),
                        ContentType = c.String(maxLength: 100),
                        Type = c.Int(nullable: false),
                        Content = c.Binary(),
                        NewsArticleId = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NewsArticles", t => t.NewsArticleId, cascadeDelete: true)
                .Index(t => t.NewsArticleId)
                .Index(t => t.IsDeleted);

            this.CreateTable(
                "dbo.Regions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsDeleted);

            this.CreateTable(
                "dbo.Visits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NewsArticleId = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NewsArticles", t => t.NewsArticleId, cascadeDelete: true)
                .Index(t => t.NewsArticleId)
                .Index(t => t.IsDeleted);

            this.CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
        }

        public override void Down()
        {
            this.DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            this.DropForeignKey("dbo.Visits", "NewsArticleId", "dbo.NewsArticles");
            this.DropForeignKey("dbo.NewsArticles", "RegionId", "dbo.Regions");
            this.DropForeignKey("dbo.Images", "NewsArticleId", "dbo.NewsArticles");
            this.DropForeignKey("dbo.NewsArticles", "NewsCategoryId", "dbo.NewsCategories");
            this.DropForeignKey("dbo.NewsArticles", "ApplicationUserId", "dbo.AspNetUsers");
            this.DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            this.DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            this.DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            this.DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            this.DropIndex("dbo.Visits", new[] { "IsDeleted" });
            this.DropIndex("dbo.Visits", new[] { "NewsArticleId" });
            this.DropIndex("dbo.Regions", new[] { "IsDeleted" });
            this.DropIndex("dbo.Images", new[] { "IsDeleted" });
            this.DropIndex("dbo.Images", new[] { "NewsArticleId" });
            this.DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            this.DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            this.DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            this.DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            this.DropIndex("dbo.AspNetUsers", "UserNameIndex");
            this.DropIndex("dbo.NewsArticles", new[] { "IsDeleted" });
            this.DropIndex("dbo.NewsArticles", new[] { "ApplicationUserId" });
            this.DropIndex("dbo.NewsArticles", new[] { "RegionId" });
            this.DropIndex("dbo.NewsArticles", new[] { "NewsCategoryId" });
            this.DropIndex("dbo.NewsCategories", new[] { "IsDeleted" });
            this.DropTable("dbo.AspNetRoles");
            this.DropTable("dbo.Visits");
            this.DropTable("dbo.Regions");
            this.DropTable("dbo.Images");
            this.DropTable("dbo.AspNetUserRoles");
            this.DropTable("dbo.AspNetUserLogins");
            this.DropTable("dbo.AspNetUserClaims");
            this.DropTable("dbo.AspNetUsers");
            this.DropTable("dbo.NewsArticles");
            this.DropTable("dbo.NewsCategories");
        }
    }
}
