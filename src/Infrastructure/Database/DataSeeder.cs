using Infrastructure.Authorization;
using Infrastructure.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Database;

public class DataSeeder(UserManager<User> userManager, RoleManager<Role> roleManager, ILogger<DataSeeder> logger)
{
    public async Task SeedAsync()
    {
        await SeedStaffRole();
        await SeedAdminRole();

        await SeedAdminUser();
    }

    private async Task SeedStaffRole()
    {
        if (await roleManager.RoleExistsAsync(Roles.Staff))
        {
            logger.LogInformation("{Role} role already exists", Roles.Staff);
            return;
        }

        await roleManager.CreateAsync(new Role() { Name = Roles.Staff });
        logger.LogInformation("{Role} role created", Roles.Staff);
    }

    private async Task SeedAdminRole()
    {
        if (await roleManager.RoleExistsAsync(Roles.Admin))
        {
            logger.LogInformation("{Role} role already exists", Roles.Admin);
            return;
        }

        await roleManager.CreateAsync(new Role() { Name = Roles.Admin });
        logger.LogInformation("{Role} role created", Roles.Admin);
    }

    private async Task SeedAdminUser()
    {
        User? user = await userManager.FindByEmailAsync(UserFaker.AdminEmail);
        if (user is not null)
        {
            logger.LogInformation("Admin user already exists");
            return;
        }

        User admin = UserFaker.CreateAdminUser();

        IdentityResult result = await userManager.CreateAsync(admin, "Admin123!");
        if (!result.Succeeded)
        {
            logger.LogError(
                "Failed to create admin user: {Errors}",
                string.Join(", ", result.Errors.Select(e => e.Description))
            );
        }

        await userManager.AddToRoleAsync(admin, Roles.Admin);

        logger.LogInformation("Admin user created");
    }
}
