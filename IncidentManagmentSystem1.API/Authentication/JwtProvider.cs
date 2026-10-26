using IncidentManagmentSystem1.API.Core.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IncidentManagmentSystem1.API.Authentication;

public class JwtProvider(IOptions<JwtOptions> jwtOptions, UserManager<ApplicationUser> userManager) : IJwtProvider
{
    private readonly JwtOptions _jwtOptions = jwtOptions.Value;
    private readonly UserManager<ApplicationUser> _userManager = userManager;

    public async Task<(string token, int expiresIn)> GenerateTokenAsync(ApplicationUser user)
    {


        var userRoles = (await _userManager.GetRolesAsync(user)).ToList();

        List<Claim> RolesClaims = new List<Claim>();

        foreach (var role in userRoles)
            RolesClaims.Add(new Claim(ClaimTypes.Role, role));






        IEnumerable<Claim> claims = new List<Claim>
        {

            new Claim (ClaimTypes.Name, user.UserName!),
            new Claim (ClaimTypes.NameIdentifier, user.Id),
            new Claim (ClaimTypes.Email, user.Email!),
            new Claim (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())

        }.Union(RolesClaims);



        SecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Key));

        SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256);

        int expireIn = _jwtOptions.ExpiryMinutes;

        JwtSecurityToken token = new JwtSecurityToken(
            issuer: _jwtOptions.Issuer,
            audience: _jwtOptions.Audience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(expireIn),
            signingCredentials: signingCredentials
            );


        return (token: new JwtSecurityTokenHandler().WriteToken(token), expireIn);

    }
}
