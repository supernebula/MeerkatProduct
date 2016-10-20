namespace Evol.Cinema.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateField : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movie", "Minutes", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movie", "Minutes", c => c.String());
        }
    }
}
