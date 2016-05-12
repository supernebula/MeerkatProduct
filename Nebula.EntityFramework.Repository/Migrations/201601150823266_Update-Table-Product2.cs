namespace Nebula.First.EFRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTableProduct2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product", "Status");
        }
    }
}
