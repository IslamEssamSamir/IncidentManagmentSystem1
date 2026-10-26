using IncidentManagmentSystem1.API.Authentication;
using IncidentManagmentSystem1.API.Core.DTOs;
using IncidentManagmentSystem1.API.Services;

namespace IncidentManagmentSystem1.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController(IAuthServices authServices) : ControllerBase
{
    private readonly IAuthServices _authServices = authServices;

    [HttpPost("")]
    public async Task<IActionResult> Login(LoginRequest loginRequest)
    {
        var authResponse = await _authServices.GetTokenAsync(loginRequest.Email, loginRequest.Password);

        if (authResponse is null)
            return Unauthorized("Invalid Email or Password");
        


        return Ok(authResponse);
    }





}
