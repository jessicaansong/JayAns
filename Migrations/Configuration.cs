using JayAns.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace JayAns.Migrations
{
    

    internal sealed class Configuration : DbMigrationsConfiguration<JayAns.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(JayAns.Models.ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(context));

            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                    roleManager.Create(new IdentityRole { Name = "Admin"});
            }
             //Create Me

            var userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));

            if (!context.Users.Any(u => u.Email == "jessica.ansong@gmail.com"))
                userManager.Create(new ApplicationUser {

                    UserName = "jessica.ansong@gmail.com",
                    Email = "jessica.ansong@gmail.com",
                    FirstName = "Jessica",
                    LastName = "Ansong",
                    DisplayName = "Jessica Ansong"
                },"spelmanite07");

        //Add Me to Admin Role

        var userId = userManager.FindByEmail("jessica.ansong@gmail.com").Id;
        userManager.AddToRole(userId, "Admin");

        //Create Moderator Role 

        var roleManager2 = new RoleManager<IdentityRole>(
            new RoleStore<IdentityRole>(context));

        if (!context.Roles.Any(r => r.Name == "Moderator"))
        {
            roleManager2.Create(new IdentityRole { Name = "Moderator" });

        }

        //Create Coderfoundry User

        var userManager2 = new UserManager<ApplicationUser>(
            new UserStore<ApplicationUser>(context));

        if (!context.Users.Any(u => u.Email == "moderator@coderfoundry.com"))
          userManager2.Create(new ApplicationUser
            {

                UserName = "moderator@coderfoundry.com",
                Email = "moderator@coderfoundry.com",
                DisplayName = "Coder Foundry Moderator"
            }, "Password-1");


        //Add Coderfoundry User to Moderator Role

        var userId2 = userManager2.FindByEmail("moderator@coderfoundry.com").Id;
        userManager2.AddToRole(userId2, "Moderator");

    }
    


                    
    }
}


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

