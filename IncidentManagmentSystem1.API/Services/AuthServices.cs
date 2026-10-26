using IncidentManagmentSystem1.API.Authentication;
using IncidentManagmentSystem1.API.Core.DTOs;

namespace IncidentManagmentSystem1.API.Services;

public class AuthServices(UserManager<ApplicationUser> userManager , IJwtProvider jwtProvider) : IAuthServices
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly IJwtProvider _jwtProvider = jwtProvider;



    public async Task<AuthResponse?> GetTokenAsync(string email, string password, CancellationToken cancellationToken = default)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user is null)
            return null;


        var isPasswordCorrect = await _userManager.CheckPasswordAsync(user, password);

        if(!isPasswordCorrect) 
            return null;


        var (token, expireIn) = await _jwtProvider.GenerateTokenAsync(user);

        AuthResponse authResponse = new()
        {
            Token = token,
            ExpireIn = expireIn,

            Id = user.Id,
            Email = email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Roles = await _userManager.GetRolesAsync(user)

        };

        return authResponse;
    }
}
