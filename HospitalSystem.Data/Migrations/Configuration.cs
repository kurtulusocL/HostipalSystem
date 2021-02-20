namespace HospitalSystem.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using HospitalSystem.Data.Data;
    using HospitalSystem.Data.Identity;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<HospitalSystem.Data.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(HospitalSystem.Data.Data.ApplicationDbContext context)
        {
            //CreateRoles(context);
            //CreateAdmin(context);
        }

        private void CreateAdmin(ApplicationDbContext context)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var user = userManager.FindByNameAsync("Admin").Result;
            if (user == null)
            {
                user = new ApplicationUser
                {
                    UserName = "kurtulus.ocL",
                    NameLastname = "Kurtulu� �cal",
                    Email = "kurtulusocal.admin@protonmail.com",
                    RespondTitle = "Admin - Software Developer",
                    Birthdate = "15.03.1989",
                    Gender = "Erkek",
                    HireDate = "27.02.2020",
                    PhoneNumber = "+905444939494",
                    EmailConfirmed = true
                };
                userManager.Create(user, "#yonas.2514#");
                userManager.AddToRole(user.Id, "Admin");
            }
            var userInRole = userManager.IsInRole(user.Id, "Admin");
            if (!userInRole)
            {
                userManager.AddToRole(user.Id, "Admin");
            }
        }

        private void CreateRoles(ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            string[] roleName = { "Admin", "User", "Helper", "Asistant" };
            foreach (var role in roleName)
            {
                if (roleManager.RoleExists(role) == false)
                {
                    var newRole = new IdentityRole { Name = role };
                    roleManager.Create(newRole);
                }
            }
        }
    }
}
