namespace ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PrivateMessages", "Status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PrivateMessages", "Status");
        }
    }
}
