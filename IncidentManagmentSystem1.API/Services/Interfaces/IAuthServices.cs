using IncidentManagmentSystem1.API.Core.DTOs.Auth;
using IncidentManagmentSystem1.API.Core.DTOs.GenericDTOs;

namespace IncidentManagmentSystem1.API.Services.Interfaces;

public interface IAuthServices
{
    public Task<ResponseResult<AuthResponse>?> GetTokenAsync(string Email, string password, CancellationToken cancellationToken = default);

}
