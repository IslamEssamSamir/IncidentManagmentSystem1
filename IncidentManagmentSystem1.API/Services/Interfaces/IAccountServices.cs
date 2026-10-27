using IncidentManagmentSystem1.API.Core.DTOs.Account;
using IncidentManagmentSystem1.API.Core.DTOs.GenericDTOs;

namespace IncidentManagmentSystem1.API.Services.Interfaces;

public interface IAccountServices
{
    public Task<ResponseResult<ProfileResponse>> GetProfileAsync(string userId);

    public Task<ResponseResult<ProfileResponse>> EditProfileAsync(string userId, EditUserProfileRequest request, CancellationToken cancellationToken = default);


}
