using IncidentManagmentSystem1.API.Core.Models;

namespace IncidentManagmentSystem1.API.Seeds;

public class DefaultUsers
{
    public static async Task SeedApplicationUsers (UserManager<ApplicationUser> userManager)
    {
        if (!userManager.Users.Any())
        {
            ApplicationUser user = new ApplicationUser
            {
                FirstName = "Admin",
                LastName = "Developers",
                UserName = "admin@Rasd.com",
                Email = "admin@Rasd.com",
                EmailConfirmed = true,
                ImageUrl = Path.Combine("images", "NoUserProfile.png")
            };

            await userManager.CreateAsync(user, "123456789");


            await userManager.AddToRolesAsync(user, new List<string> { ApplicationRoles.SuperAdmin, ApplicationRoles.Admin, ApplicationRoles.User });

        }
    }
}
