using ESTSBooks.Models;
using Microsoft.AspNetCore.Identity;

namespace ESTSBooks
{
    public static class Configurations
    {
        public static async Task CreateRoles(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<BookUser>>();
            string[] roleNames = { "Manager", "Supplier", "Default" };

            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist) await roleManager.CreateAsync(new IdentityRole(roleName));
            }

            await CreateManager(roleManager, userManager);
            await CreateSupplier(roleManager, userManager);
        }

        private static async Task CreateManager(RoleManager<IdentityRole> roleManager, UserManager<BookUser> userManager)
        {
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

        private static async Task CreateSupplier(RoleManager<IdentityRole> roleManager, UserManager<BookUser> userManager)
        {
            var supplier = new BookUser
            {
                Name = "Supplier Account",
                UserName = "supplier@ips.pt",
                Email = "supplier@ips.pt"
            };

            var _user = await userManager.FindByEmailAsync(supplier.Email);
            if (_user != null) return;

            var createPowerUser = await userManager.CreateAsync(supplier, "Password_123");
            if (createPowerUser.Succeeded)
                await userManager.AddToRoleAsync(supplier, "Supplier");
        }
    }
}
