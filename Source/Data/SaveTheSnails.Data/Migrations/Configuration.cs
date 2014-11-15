namespace SaveTheSnails.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using SaveTheSnails.Common;
    using SaveTheSnails.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AppDbContext>
    {
        private UserManager<AppUser> userManager;
        
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;

            //TODO: Set to false in production
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(AppDbContext context)
        {
            this.userManager = new UserManager<AppUser>(new UserStore<AppUser>(context));
            this.SeedRoles(context);
            this.SeedUsers(context);
            this.SeedCategories(context);
            this.SeedRegions(context);
        }

        private void SeedRoles(AppDbContext context)
        {
            context.Roles.AddOrUpdate(x => x.Name, new IdentityRole(GlobalConstants.AdminRole));
            context.Roles.AddOrUpdate(x => x.Name, new IdentityRole(GlobalConstants.CoordinatorRole));
            context.SaveChanges();
        }

        private void SeedUsers(AppDbContext context)
        {
            if (context.Users.Any())
            {
                return;
            }

            var adminUser = new AppUser
            {
                Email = "admin@sts.com",
                UserName = "admin@sts.com",
                CreatedOn = DateTime.Now
            };

            this.userManager.Create(adminUser, "123456");

            this.userManager.AddToRole(adminUser.Id, GlobalConstants.AdminRole);

            var coordinatorUser = new AppUser
            {
                Email = "cordinator1@sts.com",
                UserName = "cordinator1@sts.com",
                CreatedOn = DateTime.Now
            };

            this.userManager.Create(coordinatorUser, "123456");

            this.userManager.AddToRole(coordinatorUser.Id, GlobalConstants.CoordinatorRole);

            var onlyUser = new AppUser
            {
                Email = "firstuser@sts.com",
                UserName = "firstuser@sts.com",
                CreatedOn = DateTime.Now
            };

            this.userManager.Create(onlyUser, "123456");

        }

        private void SeedCategories(AppDbContext context)
        {
            if (context.Categories.Any())
            {
                return;
            }

            var categoires = new List<Category>();
            categoires.Add(new Category() { Name = "Категория 1" });
            categoires.Add(new Category() { Name = "Категория 2" });
            categoires.Add(new Category() { Name = "Категория 3" });
            categoires.Add(new Category() { Name = "Категория 4" });

            context.Categories.AddOrUpdate(categoires.ToArray());
        
        }

        private void SeedRegions(AppDbContext context)
        {
            if (context.Regions.Any())
            {
                return;
            }

            var regions = new List<Region>();
            regions.Add(new Region() { Name = "Регион 1" });
            regions.Add(new Region() { Name = "Регион 2" });
            regions.Add(new Region() { Name = "Регион 3" });
            regions.Add(new Region() { Name = "Регион 4" });

            context.Regions.AddOrUpdate(regions.ToArray());

        }
    }
}
