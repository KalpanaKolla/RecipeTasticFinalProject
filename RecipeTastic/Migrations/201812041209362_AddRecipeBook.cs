namespace RecipeTastic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRecipeBook : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RecipeBooks",
                c => new
                    {
                        RecipeBookId = c.Int(nullable: false, identity: true),
                        RecipeTitle = c.String(),
                        CuisineId = c.Int(nullable: false),
                        Ingredients = c.String(),
                        ReadyInMinutes = c.Int(nullable: false),
                        Servings = c.Int(nullable: false),
                        UserId = c.String(),
                    })
                .PrimaryKey(t => t.RecipeBookId)
                .ForeignKey("dbo.Cuisines", t => t.CuisineId, cascadeDelete: true)
                .Index(t => t.CuisineId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RecipeBooks", "CuisineId", "dbo.Cuisines");
            DropIndex("dbo.RecipeBooks", new[] { "CuisineId" });
            DropTable("dbo.RecipeBooks");
        }
    }
}
