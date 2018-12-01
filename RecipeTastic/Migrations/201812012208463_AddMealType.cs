namespace RecipeTastic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMealType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MealTypes",
                c => new
                    {
                        MealTypeId = c.Int(nullable: false, identity: true),
                        MealTypeName = c.String(),
                    })
                .PrimaryKey(t => t.MealTypeId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MealTypes");
        }
    }
}
