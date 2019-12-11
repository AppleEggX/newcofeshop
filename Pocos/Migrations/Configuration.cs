namespace Pocos.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Pocos.Model1>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Pocos.Model1 context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            //context.Coffees.AddOrUpdate(x => x.Id,
            //    new Coffee()
            //    {
            //        Id = 1,
            //        Name = "First Coffee Bean",
            //        Origin = "Vietnam",
            //        Type = "Robusta",
            //        Rating = 3.5,
            //        Story = "We can say with some degree of confidence the only thing not affected by the war in Vietnam was coffee. In Vietnam, people prefer the Robusta coffee bean with a strong taste. In fact, Vietnam can be said to be the native land of Robusta. Vietnam is among top coffee exporters in the world",
            //        TastingNote = "Strong taste",
            //        Price = 200,
            //        Storage = 10
            //    },
            //    new Coffee()
            //    {
            //        Id = 2,
            //        Name = "Good Coffee Bean",
            //        Origin = "Indonesia",
            //        Type = "Robusta & Arabica",
            //        Rating = 4,
            //        Story = "Indonesia, which we frequently hear associated with interesting coffee types, produces 660,000,000 kg of coffee per year. Although quality and taste pale in comparison to Brazil and Colombia, it has an important place in global coffee production.",
            //        TastingNote = "Pale taste in comparison to Brazil and Colombia",
            //        Price = 150,
            //        Storage = 5
            //    },
            //    new Coffee()
            //    {
            //        Id = 3,
            //        Name = "Hot Coffee Beam",
            //        Origin = "Brazil",
            //        Type = "Arabica",
            //        Rating = 4.95,
            //        Story = "As you know, Brazil is one of the top coffee producing countries. In Brazil, 2,594,100 tons of coffee was produced in 2016. Among the reasons for the coffee grown in Brazil being so tasty are the wide production areas and the premium quality of the product. The coffee produced in Brazil is often preferred because it has low acidity.",
            //        TastingNote = "Low acidity taste",
            //        Price = 330,
            //        Storage = 40
            //    },
            //    new Coffee()
            //    {
            //        Id = 4,
            //        Name = "Colomiba Beam",
            //        Origin = "Colomiba",
            //        Type = "Arabica",
            //        Rating = 4.75,
            //        Story = "Colombia, which claims a fair share of coffee production with 810,000,000 kg per year, is just behind Brazil in terms of taste with its Arabica coffee bean. Among the delicious coffee types of Colombia are Extra and Supremo.",
            //        TastingNote = "Just behind Brazil taste",
            //        Price = 225,
            //        Storage = 16
            //    }
            //    );
            //context.Users.AddOrUpdate(x => x.Id,
            //    new User() { Id = 1, Name = "Admin", Password = "default", Admin = true },
            //    new User() { Id = 2, Name = "TestUser", Password = "pwd", Admin = false },
            //    new User() { Id = 3, Name = "Shawn", Password = "password", Admin = false }
            //);

            //context.Baskets.AddOrUpdate(x => x.Id,
            //  new Basket() { Id = 1, User = context.Users.FirstOrDefault(u => u.Name == "TestUser") },
            //  new Basket() { Id = 2, User = context.Users.Find(3) }
            //   );

            //context.BasketItems.AddOrUpdate(x => x.Id,
            //   new BasketItem()
            //   {
            //       Coffee = context.Coffees.FirstOrDefault<Coffee>(),
            //       Amount = 1,
            //       TotalPrice = 1 * context.Coffees.FirstOrDefault<Coffee>().Price,
            //       Basket = context.Baskets.FirstOrDefault()
            //   },
            //   new BasketItem()
            //   {
            //       Coffee = context.Coffees.FirstOrDefault<Coffee>(x => x.Id == 3),
            //       Amount = 3,
            //       TotalPrice = 3 * context.Coffees.FirstOrDefault<Coffee>(x => x.Id == 3).Price,
            //       Basket = context.Baskets.FirstOrDefault(x => x.User == (context.Users.FirstOrDefault(u => u.Name == "TestUser")))
            //   },
            //   new BasketItem()
            //   {
            //       Coffee = context.Coffees.Find(2),
            //       Amount = 2,
            //       TotalPrice = 2 * context.Coffees.Find(2).Price,
            //       Basket = context.Baskets.Find(2)
            //   }
            //   );

        }
    }
}
