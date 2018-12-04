namespace RecipeTastic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMealDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "MealDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Items", "MealDate");
        }
    }
}
