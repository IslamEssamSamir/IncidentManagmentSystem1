using AutoMapper;
using IncidentManagmentSystem1.API.Authentication;
using IncidentManagmentSystem1.API.Core.DTOs.Account;
using IncidentManagmentSystem1.API.Core.DTOs.Auth;
using IncidentManagmentSystem1.API.Core.DTOs.GenericDTOs;
using IncidentManagmentSystem1.API.Services.Interfaces;

namespace IncidentManagmentSystem1.API.Services.Implementations;

public class AuthServices(UserManager<ApplicationUser> userManager , IJwtProvider jwtProvider , IMapper mapper) : IAuthServices
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly IJwtProvider _jwtProvider = jwtProvider;
    private readonly IMapper _mapper = mapper;

    public async Task<ResponseResult<AuthResponse>?> GetTokenAsync(string email, string password, CancellationToken cancellationToken = default)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user is null)
            return ResponseResult<AuthResponse>.FailureError("Invalid Email or Password", HttpStatusCode.Unauthorized);


        var isPasswordCorrect = await _userManager.CheckPasswordAsync(user, password);

        if(!isPasswordCorrect) 
            return ResponseResult<AuthResponse>.FailureError("Invalid Email or Password", HttpStatusCode.Unauthorized);


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

        ResponseResult<AuthResponse> responseResult = ResponseResult<AuthResponse>.Success(authResponse);

        return responseResult;
    }

    

    public Task<ResponseResult<ProfileResponse>> EditProfileAsync(EditUserProfileRequest request, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

   

}
