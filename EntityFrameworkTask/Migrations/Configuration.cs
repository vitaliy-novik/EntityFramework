using EntityFrameworkTask.Models;

namespace EntityFrameworkTask.Migrations
{
	using System.Data.Entity.Migrations;

	internal sealed class Configuration : DbMigrationsConfiguration<NorthwindDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(NorthwindDb context)
        {
			context.Categories.AddOrUpdate(
				new Category { CategoryName = "Beverages", Description = "Soft drinks, coffees, teas, beers, and ales" },
				new Category { CategoryName = "Condiments", Description = "Sweet and savory sauces, relishes, spreads, and seasonings" },
				new Category { CategoryName = "Confections", Description = "Desserts, candies, and sweet breads" },
				new Category { CategoryName = "Dairy Products", Description = "Cheeses" });

			context.Regions.AddOrUpdate(
				new Region { RegionID = 1, RegionDescription = "Eastern" },
				new Region { RegionID = 2, RegionDescription = "Western" },
				new Region { RegionID = 3, RegionDescription = "Southern" },
				new Region { RegionID = 4, RegionDescription =  "Northern" });

			context.Territories.AddOrUpdate(
				new Territory { TerritoryID = "10ER", TerritoryDescription = "Westboro", RegionID = 1},
				new Territory { TerritoryID = "2FK5", TerritoryDescription = "Bedford", RegionID = 2},
				new Territory { TerritoryID = "3FV5", TerritoryDescription = "Boston", RegionID = 4},
				new Territory { TerritoryID = "4FF8", TerritoryDescription = "Hollis", RegionID = 2});

	        context.SaveChanges();
		}
	}
}
