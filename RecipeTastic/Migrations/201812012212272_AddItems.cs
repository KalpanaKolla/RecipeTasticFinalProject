namespace RecipeTastic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddItems : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ItemId = c.Int(nullable: false, identity: true),
                        ItemName = c.String(),
                        CuisineId = c.Int(nullable: false),
                        MealTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ItemId)
                .ForeignKey("dbo.Cuisines", t => t.CuisineId, cascadeDelete: true)
                .ForeignKey("dbo.MealTypes", t => t.MealTypeId, cascadeDelete: true)
                .Index(t => t.CuisineId)
                .Index(t => t.MealTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "MealTypeId", "dbo.MealTypes");
            DropForeignKey("dbo.Items", "CuisineId", "dbo.Cuisines");
            DropIndex("dbo.Items", new[] { "MealTypeId" });
            DropIndex("dbo.Items", new[] { "CuisineId" });
            DropTable("dbo.Items");
        }
    }
}
