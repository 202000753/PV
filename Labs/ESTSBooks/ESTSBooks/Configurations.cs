using ESTSBooks.Models;
using Microsoft.AspNetCore.Identity;

namespace ESTSBooks
{
    public class Configurations
    {
        public static async Task CreateRoles(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<BookUser>>();
            string[] roleNames = { "Manager", "Default" };
            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist) await roleManager.CreateAsync(new IdentityRole(roleName));
            }
            var manager = new BookUser
            {
                Name = "Manager Account",
                UserName = "manager@ips.pt",
                Email = "manager@ips.pt"
            };
            var _user = await userManager.FindByEmailAsync(manager.Email);
            if (_user != null) return;
            var createPowerUser = await userManager.CreateAsync(manager, "Password_123");
            if (createPowerUser.Succeeded)
                await userManager.AddToRoleAsync(manager, "Manager");
        }
    }
}
