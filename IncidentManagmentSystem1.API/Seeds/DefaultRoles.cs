using IncidentManagmentSystem1.API.Core.Models;

namespace IncidentManagmentSystem1.API.Seeds;

public class DefaultRoles
{
    public static async Task SeedApplicationRoles (RoleManager<IdentityRole> roleManager)
    {
        if (!roleManager.Roles.Any())
        {
            await roleManager.CreateAsync(new IdentityRole(ApplicationRoles.SuperAdmin));
            await roleManager.CreateAsync(new IdentityRole(ApplicationRoles.Admin));
            await roleManager.CreateAsync(new IdentityRole(ApplicationRoles.User));
        }
    }
}
