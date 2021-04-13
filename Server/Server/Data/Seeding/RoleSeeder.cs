using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Server.Data.Models;
using Server.Data.Seeding.Contracts;

namespace Server.Data.Seeding
{
    public class RoleSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (!dbContext.Roles.Any())
            {
                var roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

                await SeedRoleAsync(roleManager, "Administrator");
                await SeedRoleAsync(roleManager, "Student");
            }
        }

        private static async Task SeedRoleAsync(RoleManager<ApplicationRole> roleManager, string roleName)
        {
            var result = await roleManager.CreateAsync(new ApplicationRole() {Name = roleName});
            if (result.Errors.Any())
            {
                throw new Exception(string.Join(Environment.NewLine, result.Errors.Select(e => e.Description)));
            }
        }
    }
}