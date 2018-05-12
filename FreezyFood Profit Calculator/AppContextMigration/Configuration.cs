namespace FreezyFood_Profit_Calculator.AppContextMigration
{
    using FreezyFood_Profit_Calculator.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FreezyFood_Profit_Calculator.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"AppContextMigration";
            ContextKey = "FreezyFood_Profit_Calculator.Models.ApplicationDbContext";
        }

        protected override void Seed(FreezyFood_Profit_Calculator.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);


            if (!roleManager.RoleExists("Admin"))
            {
                roleManager.Create(new IdentityRole("Admin"));
                context.SaveChanges();
            }

            var user = userManager.FindByEmail("bane@freezy.com");
            var roleForUser = userManager.GetRoles(user.Id);

            if (!roleForUser.Contains("Admin"))
            {
                userManager.AddToRole(user.Id, "Admin");
                context.SaveChanges();
            }
        }
    }
}
