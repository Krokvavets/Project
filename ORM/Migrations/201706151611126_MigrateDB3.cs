namespace ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Topics", "CreationDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Topics", "CreationDate", c => c.DateTime(nullable: false));
        }
    }
}
