namespace Pocos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class creatingTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BasketItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Int(nullable: false),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Basket_Id = c.Int(),
                        Coffee_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Baskets", t => t.Basket_Id)
                .ForeignKey("dbo.Coffees", t => t.Coffee_Id)
                .Index(t => t.Basket_Id)
                .Index(t => t.Coffee_Id);
            
            CreateTable(
                "dbo.Baskets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SumPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Password = c.String(),
                        Admin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Coffees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Origin = c.String(),
                        Type = c.String(),
                        Rating = c.Double(nullable: false),
                        TastingNote = c.String(),
                        Story = c.String(),
                        Storage = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BasketItems", "Coffee_Id", "dbo.Coffees");
            DropForeignKey("dbo.Baskets", "User_Id", "dbo.Users");
            DropForeignKey("dbo.BasketItems", "Basket_Id", "dbo.Baskets");
            DropIndex("dbo.Baskets", new[] { "User_Id" });
            DropIndex("dbo.BasketItems", new[] { "Coffee_Id" });
            DropIndex("dbo.BasketItems", new[] { "Basket_Id" });
            DropTable("dbo.Coffees");
            DropTable("dbo.Users");
            DropTable("dbo.Baskets");
            DropTable("dbo.BasketItems");
        }
    }
}
