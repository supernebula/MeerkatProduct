namespace Nebula.Cinema.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Actor",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        ImagePath = c.String(),
                        Movie_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movie", t => t.Movie_Id)
                .Index(t => t.Movie_Id);
            
            CreateTable(
                "dbo.Movie",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        ForeignName = c.String(),
                        ReleaseDate = c.DateTime(nullable: false),
                        Minutes = c.String(),
                        ReleaseRegion = c.String(),
                        SpaceDimension = c.Int(nullable: false),
                        CoverUri = c.String(),
                        Description = c.String(),
                        Ratings = c.Single(nullable: false),
                        Language = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Screening",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        ScreeningRoomId = c.Guid(nullable: false),
                        MovieId = c.Guid(nullable: false),
                        Price = c.Double(nullable: false),
                        SellPrice = c.Double(nullable: false),
                        SpaceType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ScreeningRoom",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        SpaceDimension = c.Int(nullable: false),
                        SpaceType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Seat",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        SeatType = c.Int(nullable: false),
                        RowNo = c.Int(nullable: false),
                        ColumnNo = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        ScreeningRoom_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ScreeningRoom", t => t.ScreeningRoom_Id)
                .Index(t => t.ScreeningRoom_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Seat", "ScreeningRoom_Id", "dbo.ScreeningRoom");
            DropForeignKey("dbo.Actor", "Movie_Id", "dbo.Movie");
            DropIndex("dbo.Seat", new[] { "ScreeningRoom_Id" });
            DropIndex("dbo.Actor", new[] { "Movie_Id" });
            DropTable("dbo.Seat");
            DropTable("dbo.ScreeningRoom");
            DropTable("dbo.Screening");
            DropTable("dbo.Movie");
            DropTable("dbo.Actor");
        }
    }
}
