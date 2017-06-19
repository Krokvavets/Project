namespace ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PrivateMessages", "RecipientId", c => c.Int(nullable: false));
            AddColumn("dbo.PrivateMessages", "SenderId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PrivateMessages", "SenderId");
            DropColumn("dbo.PrivateMessages", "RecipientId");
        }
    }
}
