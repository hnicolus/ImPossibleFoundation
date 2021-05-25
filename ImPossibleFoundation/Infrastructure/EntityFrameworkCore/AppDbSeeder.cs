using CodeClinic.Infrastructure.Identity;
using ImPossibleFoundation.Blog;
using ImPossibleFoundation.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImPossibleFoundation.Infrastructure.EntityFrameworkCore
{
    public static class AppDbSeeder
    {
        private static AppUser _defaultUser;

        public static async Task InitializeAsync(AppDbContext context, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            context.Database.EnsureCreated();
            await SeedDefaultUserAsync(userManager, roleManager);
            await SeedBlogDataAsync(context);

        }
        private static async Task SeedDefaultUserAsync(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            var administratorRole = new AppRole("Administrator");

            if (roleManager.Roles.All(r => r.Name != administratorRole.Name))
            {
                await roleManager.CreateAsync(administratorRole);
            }

            var administrator = new AppUser { UserName = "admin", Email = "administrator@impossibleFoundation.co.za" };
            _defaultUser = administrator;
            if (userManager.Users.All(u => u.UserName != administrator.UserName))
            {
                await userManager.CreateAsync(administrator, "P@ssw0rd!");
                await userManager.AddToRolesAsync(administrator, new[] { administratorRole.Name });
            }
        }

        private static async Task SeedBlogDataAsync(AppDbContext context)
        {

            if (!context.Articles.Any())
            {
                var article1 = Article.Create("Welcome to ImPossible Foundation", "Welcome to ImPossible Foundation", "/images/image_1.jpg");
                article1.CreatedBy = _defaultUser.Id;
                article1.Created = DateTime.Now;
                var art2 = Article.Create("Second Blog Post", "Welcome to ImPossible Foundation", "/images/image_2.jpg");
                art2.CreatedBy = _defaultUser.Id;
                art2.Created = DateTime.Now;
                await context.AddAsync(article1);
                await context.AddAsync(art2);
            }


            await context.SaveChangesAsync();
        }
    }
}
