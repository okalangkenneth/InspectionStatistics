using InspectionStatistics.Identity.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace InspectionStatistics.Identity.Seed
{
    public static class UserCreator
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager)
        {
            var applicationUser = new ApplicationUser
            {
                FirstName = "Kenneth",
                LastName = "Okalang",
                UserName = "kennethokalang",
                Email = "ken@test.com",
                EmailConfirmed = true
            };

            var user = await userManager.FindByEmailAsync(applicationUser.Email);
            if (user == null)
            {
                await userManager.CreateAsync(applicationUser, "Plural&01?");
            }
        }
    }
}
