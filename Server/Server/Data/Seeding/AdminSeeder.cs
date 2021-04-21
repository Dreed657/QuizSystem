using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Server.Data.Models;
using Server.Data.Seeding.Contracts;

namespace Server.Data.Seeding
{
    public class AdminSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (!dbContext.Users.Any())
            {
                var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                await SeedAdminAsync(userManager);
            }
        }

        private static async Task SeedAdminAsync(UserManager<ApplicationUser> userManager)
        {
            var admin = await userManager.FindByNameAsync("Administrator01");

            if (admin == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "Administrator01",
                    Email = "admin@gmail.com",
                };

                // TODO: HIDE ADMIN PASSWORD INTO .ENV / APP CONFIG
                await userManager.CreateAsync(user, "password");
                await userManager.AddToRoleAsync(user, "Administrator");
            }
        }
    }
}