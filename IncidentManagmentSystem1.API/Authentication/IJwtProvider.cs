using IncidentManagmentSystem1.API.Core.Models;

namespace IncidentManagmentSystem1.API.Authentication;

public interface IJwtProvider
{
    Task<(string token, int expiresIn)> GenerateTokenAsync(ApplicationUser user);
}
