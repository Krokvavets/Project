namespace ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(nullable: false),
                        Footer = c.String(),
                        Note = c.String(),
                        Quote = c.String(),
                        UserId = c.Int(nullable: false),
                        TopicId = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Topics", t => t.TopicId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.TopicId);
            
            CreateTable(
                "dbo.Topics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        SectionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sections", t => t.SectionId, cascadeDelete: true)
                .Index(t => t.SectionId);
            
            CreateTable(
                "dbo.Sections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Nickname = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Photo = c.Binary(),
                        CreationDate = c.DateTime(nullable: false),
                        NumberOfPosts = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PrivateMessages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        Preview = c.String(),
                        Recipient_Id = c.Int(),
                        Sender_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Recipient_Id)
                .ForeignKey("dbo.Users", t => t.Sender_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Recipient_Id)
                .Index(t => t.Sender_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RoleUsers",
                c => new
                    {
                        Role_Id = c.Int(nullable: false),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Role_Id, t.User_Id })
                .ForeignKey("dbo.Roles", t => t.Role_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.Role_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RoleUsers", "User_Id", "dbo.Users");
            DropForeignKey("dbo.RoleUsers", "Role_Id", "dbo.Roles");
            DropForeignKey("dbo.PrivateMessages", "User_Id", "dbo.Users");
            DropForeignKey("dbo.PrivateMessages", "Sender_Id", "dbo.Users");
            DropForeignKey("dbo.PrivateMessages", "Recipient_Id", "dbo.Users");
            DropForeignKey("dbo.Messages", "UserId", "dbo.Users");
            DropForeignKey("dbo.Topics", "SectionId", "dbo.Sections");
            DropForeignKey("dbo.Messages", "TopicId", "dbo.Topics");
            DropIndex("dbo.RoleUsers", new[] { "User_Id" });
            DropIndex("dbo.RoleUsers", new[] { "Role_Id" });
            DropIndex("dbo.PrivateMessages", new[] { "User_Id" });
            DropIndex("dbo.PrivateMessages", new[] { "Sender_Id" });
            DropIndex("dbo.PrivateMessages", new[] { "Recipient_Id" });
            DropIndex("dbo.Topics", new[] { "SectionId" });
            DropIndex("dbo.Messages", new[] { "TopicId" });
            DropIndex("dbo.Messages", new[] { "UserId" });
            DropTable("dbo.RoleUsers");
            DropTable("dbo.Roles");
            DropTable("dbo.PrivateMessages");
            DropTable("dbo.Users");
            DropTable("dbo.Sections");
            DropTable("dbo.Topics");
            DropTable("dbo.Messages");
        }
    }
}
