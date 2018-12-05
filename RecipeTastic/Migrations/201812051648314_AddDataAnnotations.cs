namespace RecipeTastic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cuisines", "CuisineName", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Groceries", "GroceryName", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Items", "ItemName", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Items", "MealDate", c => c.DateTime());
            AlterColumn("dbo.MealTypes", "MealTypeName", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.RecipeBooks", "RecipeTitle", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RecipeBooks", "RecipeTitle", c => c.String());
            AlterColumn("dbo.MealTypes", "MealTypeName", c => c.String());
            AlterColumn("dbo.Items", "MealDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Items", "ItemName", c => c.String());
            AlterColumn("dbo.Groceries", "GroceryName", c => c.String());
            AlterColumn("dbo.Cuisines", "CuisineName", c => c.String());
        }
    }
}
