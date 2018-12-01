namespace RecipeTastic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMealTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MealTypes(MealTypeName)VALUES('Breakfast')");
            Sql("INSERT INTO MealTypes(MealTypeName)VALUES('Lunch')");
            Sql("INSERT INTO MealTypes(MealTypeName)VALUES('Dinner')");
        }
        
        public override void Down()
        {
        }
    }
}
