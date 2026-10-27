using AutoMapper;
using Azure;
using IncidentManagmentSystem1.API.Authentication;
using IncidentManagmentSystem1.API.Core.DTOs.Account;
using IncidentManagmentSystem1.API.Core.DTOs.GenericDTOs;
using IncidentManagmentSystem1.API.Services.Interfaces;

namespace IncidentManagmentSystem1.API.Services.Implementations;

public class AccountServices(UserManager<ApplicationUser> userManager, IMapper mapper, IFileServices fileServices) : IAccountServices
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly IMapper _mapper = mapper;
    private readonly IFileServices _fileServices = fileServices;

    public async Task<ResponseResult<ProfileResponse>> GetProfileAsync(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user is null)
            return ResponseResult<ProfileResponse>.FailureError("User Not Found!", HttpStatusCode.NotFound);

        var userProfile = _mapper.Map<ProfileResponse>(user);

        var userRoles = await _userManager.GetRolesAsync(user);

        userProfile.Role = userRoles.ToList();

        return ResponseResult<ProfileResponse>.Success(userProfile);

    }




    public async Task<ResponseResult<ProfileResponse>> EditProfileAsync(string userId ,EditUserProfileRequest request, CancellationToken cancellationToken = default)
    {


        var user = await _userManager.FindByIdAsync(userId);
        if (user is null)
            return ResponseResult<ProfileResponse>.FailureError("User Not Found!", HttpStatusCode.NotFound);

        user = _mapper.Map(request, user);

        if (request.Image is not null)
        {
            (bool isUploaded, string? errorMessage, string? imagePath) = await _fileServices
                .UploadAsync(request.Image, Path.Combine("images", "Accounts"));

            if (!isUploaded)
            {
                Dictionary<string, string[]> Errors = new();

                Errors.Add(nameof(EditUserProfileRequest.Image), [errorMessage??"Image is not Valid!"]);
                return ResponseResult<ProfileResponse>.FailureErrors(Errors, HttpStatusCode.BadRequest);
             
            }


            if (user.ImageUrl != Path.Combine("images", "NoUserProfile.png") && !string.IsNullOrEmpty(user.ImageUrl))
                _fileServices.Delete(user.ImageUrl);


            user.ImageUrl = imagePath;

        }


        user.UpdatedById = user.Id;
        user.LastUpdatedOn = DateTime.Now;
        await _userManager.UpdateAsync(user);

        var profile = _mapper.Map<ProfileResponse>(user);
        profile.Role = (await _userManager.GetRolesAsync(user)).ToList();
        var response = ResponseResult<ProfileResponse>.Success(profile);

        return response;
    }
}
