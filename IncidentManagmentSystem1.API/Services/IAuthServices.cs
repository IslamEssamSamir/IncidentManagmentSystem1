using IncidentManagmentSystem1.API.Core.DTOs;

namespace IncidentManagmentSystem1.API.Services;

public interface IAuthServices
{
    public Task<AuthResponse?> GetTokenAsync(string Email, string password, CancellationToken cancellationToken = default);
}
