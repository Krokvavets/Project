namespace ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PrivateMessages", "Recipient_Id", "dbo.Users");
            DropForeignKey("dbo.PrivateMessages", "Sender_Id", "dbo.Users");
            DropIndex("dbo.PrivateMessages", new[] { "Recipient_Id" });
            DropIndex("dbo.PrivateMessages", new[] { "Sender_Id" });
            DropColumn("dbo.PrivateMessages", "Recipient_Id");
            DropColumn("dbo.PrivateMessages", "Sender_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PrivateMessages", "Sender_Id", c => c.Int());
            AddColumn("dbo.PrivateMessages", "Recipient_Id", c => c.Int());
            CreateIndex("dbo.PrivateMessages", "Sender_Id");
            CreateIndex("dbo.PrivateMessages", "Recipient_Id");
            AddForeignKey("dbo.PrivateMessages", "Sender_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.PrivateMessages", "Recipient_Id", "dbo.Users", "Id");
        }
    }
}
