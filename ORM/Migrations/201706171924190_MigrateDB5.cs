namespace ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Sections", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Sections", "Name", c => c.String());
        }
    }
}
