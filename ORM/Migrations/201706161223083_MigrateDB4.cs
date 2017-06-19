namespace ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "AboutMe", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "AboutMe");
        }
    }
}
