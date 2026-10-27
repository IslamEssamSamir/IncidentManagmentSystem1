using IncidentManagmentSystem1.API.Authentication;
using IncidentManagmentSystem1.API.Core.DTOs.Auth;
using IncidentManagmentSystem1.API.Services.Interfaces;

namespace IncidentManagmentSystem1.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController(IAuthServices authServices) : ControllerBase
{
    private readonly IAuthServices _authServices = authServices;


    /// <summary>
    /// Authenticates a user and returns a JWT token if the credentials are valid.
    /// </summary>
    /// <param name="loginRequest">The login request containing user credentials.</param>
    /// <returns>An HTTP 200 response with the authentication token if successful; otherwise, HTTP 401 if authentication fails.</returns>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [HttpPost("")]
    public async Task<IActionResult> Login(LoginRequest loginRequest)
    {
        var authResponse = await _authServices.GetTokenAsync(loginRequest.Email, loginRequest.Password);

        if (authResponse.IsSuccess)

            return Ok(authResponse);
        else

            return Unauthorized(authResponse);

        ;
    }


    //[HttpPost("")]
    //public async Task<IActionResult> CreateNewUser()
    //{

    //    return Ok();
    //}

}
