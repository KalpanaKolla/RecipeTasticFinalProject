namespace RecipeTastic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGrocery : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Groceries",
                c => new
                    {
                        GroceryId = c.Int(nullable: false, identity: true),
                        GroceryName = c.String(),
                        GroceryComment = c.String(),
                        UserId = c.String(),
                    })
                .PrimaryKey(t => t.GroceryId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Groceries");
        }
    }
}
