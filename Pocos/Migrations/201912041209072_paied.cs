namespace Pocos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class paied : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Baskets", "Paied", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Baskets", "Paied");
        }
    }
}
