namespace WineMap.DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Wine",
                c => new
                    {
                        WineId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.WineId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Wine");
        }
    }
}
