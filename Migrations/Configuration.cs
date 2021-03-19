namespace TruYumWeb.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TtruYum.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TtruYum.Models.TruYumContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TtruYum.Models.TruYumContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            var category = new List<Category>
            {
                new Category{Id=1,Name="Main Course"},
                new Category{Id=2,Name="Staters"},
                new Category{Id=3,Name="Snack"}
            };
            category.ForEach(ns => context.Categories.AddOrUpdate(x => x.Id, ns));
            category.ForEach(ns => context.Categories.AddOrUpdate(x => x.Name, ns));
        }
    }
}
