namespace WineMap.DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSevenTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Country",
                c => new
                    {
                        CountryId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.CountryId);
            
            CreateTable(
                "dbo.Grape",
                c => new
                    {
                        GrapeId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.GrapeId);
            
            CreateTable(
                "dbo.WinePhoto",
                c => new
                    {
                        PhotoId = c.Int(nullable: false, identity: true),
                        WineId = c.Int(nullable: false),
                        Name = c.String(maxLength: 50),
                        OriginalName = c.String(maxLength: 256),
                        ContentType = c.String(maxLength: 100),
                        Order = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PhotoId)
                .ForeignKey("dbo.Wine", t => t.WineId)
                .Index(t => t.WineId);
            
            CreateTable(
                "dbo.Price",
                c => new
                    {
                        PriceId = c.Int(nullable: false, identity: true),
                        WineId = c.Int(nullable: false),
                        Volume = c.Int(nullable: false),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Discount = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.PriceId)
                .ForeignKey("dbo.Wine", t => t.WineId)
                .Index(t => t.WineId);
            
            CreateTable(
                "dbo.Region",
                c => new
                    {
                        RegionId = c.Int(nullable: false, identity: true),
                        CountryId = c.Int(nullable: false),
                        Name = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.RegionId)
                .ForeignKey("dbo.Country", t => t.CountryId)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.Tag",
                c => new
                    {
                        TagId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.TagId);
            
            CreateTable(
                "dbo.WineGrape",
                c => new
                    {
                        WineId = c.Int(nullable: false),
                        GrapeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.WineId, t.GrapeId })
                .ForeignKey("dbo.Wine", t => t.WineId)
                .ForeignKey("dbo.Grape", t => t.GrapeId)
                .Index(t => t.WineId)
                .Index(t => t.GrapeId);
            
            CreateTable(
                "dbo.WineTag",
                c => new
                    {
                        WineId = c.Int(nullable: false),
                        TagId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.WineId, t.TagId })
                .ForeignKey("dbo.Wine", t => t.WineId)
                .ForeignKey("dbo.Tag", t => t.TagId)
                .Index(t => t.WineId)
                .Index(t => t.TagId);
            
            AddColumn("dbo.Wine", "Type", c => c.Int(nullable: false));
            AddColumn("dbo.Wine", "CountryId", c => c.Int(nullable: false));
            AddColumn("dbo.Wine", "RegionId", c => c.Int(nullable: false));
            AddColumn("dbo.Wine", "Color", c => c.Int(nullable: false));
            AddColumn("dbo.Wine", "Sugar", c => c.Int(nullable: false));
            AddColumn("dbo.Wine", "Alcohol", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Wine", "Description", c => c.String(maxLength: 2000));
            AddColumn("dbo.Wine", "History", c => c.String(maxLength: 2000));
            CreateIndex("dbo.Wine", "CountryId");
            CreateIndex("dbo.Wine", "RegionId");
            AddForeignKey("dbo.Wine", "CountryId", "dbo.Country", "CountryId");
            AddForeignKey("dbo.Wine", "RegionId", "dbo.Region", "RegionId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WineTag", "TagId", "dbo.Tag");
            DropForeignKey("dbo.WineTag", "WineId", "dbo.Wine");
            DropForeignKey("dbo.Wine", "RegionId", "dbo.Region");
            DropForeignKey("dbo.Region", "CountryId", "dbo.Country");
            DropForeignKey("dbo.Price", "WineId", "dbo.Wine");
            DropForeignKey("dbo.WinePhoto", "WineId", "dbo.Wine");
            DropForeignKey("dbo.WineGrape", "GrapeId", "dbo.Grape");
            DropForeignKey("dbo.WineGrape", "WineId", "dbo.Wine");
            DropForeignKey("dbo.Wine", "CountryId", "dbo.Country");
            DropIndex("dbo.WineTag", new[] { "TagId" });
            DropIndex("dbo.WineTag", new[] { "WineId" });
            DropIndex("dbo.WineGrape", new[] { "GrapeId" });
            DropIndex("dbo.WineGrape", new[] { "WineId" });
            DropIndex("dbo.Region", new[] { "CountryId" });
            DropIndex("dbo.Price", new[] { "WineId" });
            DropIndex("dbo.WinePhoto", new[] { "WineId" });
            DropIndex("dbo.Wine", new[] { "RegionId" });
            DropIndex("dbo.Wine", new[] { "CountryId" });
            DropColumn("dbo.Wine", "History");
            DropColumn("dbo.Wine", "Description");
            DropColumn("dbo.Wine", "Alcohol");
            DropColumn("dbo.Wine", "Sugar");
            DropColumn("dbo.Wine", "Color");
            DropColumn("dbo.Wine", "RegionId");
            DropColumn("dbo.Wine", "CountryId");
            DropColumn("dbo.Wine", "Type");
            DropTable("dbo.WineTag");
            DropTable("dbo.WineGrape");
            DropTable("dbo.Tag");
            DropTable("dbo.Region");
            DropTable("dbo.Price");
            DropTable("dbo.WinePhoto");
            DropTable("dbo.Grape");
            DropTable("dbo.Country");
        }
    }
}
