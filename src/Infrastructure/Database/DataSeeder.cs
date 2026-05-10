using Infrastructure.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Database;

public class DataSeeder(RoleManager<Role> roleManager, ILogger<DataSeeder> logger)
{
    public async Task SeedAsync()
    {
        await SeedStaffRole();
        await SeedAdminRole();
    }

    private async Task SeedAdminRole()
    {
        if (await roleManager.RoleExistsAsync(Roles.Staff))
        {
            logger.LogInformation("{Role} role already exists", Roles.Staff);
            return;
        }

        await roleManager.CreateAsync(new Role() { Name = Roles.Staff });
        logger.LogInformation("{Role} role created", Roles.Staff);
    }

    private async Task SeedStaffRole()
    {
        if (await roleManager.RoleExistsAsync(Roles.Admin))
        {
            logger.LogInformation("{Role} role already exists", Roles.Admin);
            return;
        }

        await roleManager.CreateAsync(new Role() { Name = Roles.Admin });
        logger.LogInformation("{Role} role created", Roles.Staff);
    }
}
