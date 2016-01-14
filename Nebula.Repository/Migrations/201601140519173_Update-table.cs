namespace Nebula.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updatetable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "MarkDelete", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product", "MarkDelete");
        }
    }
}
