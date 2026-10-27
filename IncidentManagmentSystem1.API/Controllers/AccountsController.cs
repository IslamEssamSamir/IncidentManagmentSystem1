using IncidentManagmentSystem1.API.Core.DTOs.Account;
using IncidentManagmentSystem1.API.Services.Implementations;
using IncidentManagmentSystem1.API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace IncidentManagmentSystem1.API.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class AccountsController(IAccountServices accountServices) : ControllerBase
{
    private readonly IAccountServices _accountServices = accountServices;

    /// <summary>
    /// Retrieves the profile information for the authenticated user.
    /// </summary>
    /// <param name="cancellation">A token to monitor for cancellation requests.</param>
    /// <returns>An HTTP 200 response with the profile data if found; otherwise, an appropriate error response.</returns>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("GetProfile")]
    public async Task<ActionResult> GetProfile(CancellationToken cancellation)
    {


        var response = await _accountServices.GetProfileAsync(User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);


        if (response.StatusCode == HttpStatusCode.Unauthorized)
            return Unauthorized(response);
        else
            return Ok(response);
    }
     

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPost("EditProfile")]
    public async Task<ActionResult> EditProfile([FromForm] EditUserProfileRequest request)
    {
        var response = await _accountServices
            .EditProfileAsync(User.FindFirst(ClaimTypes.NameIdentifier)?.Value!, request);

        if (!response.IsSuccess)
        {
            switch (response.StatusCode)
            {
                case HttpStatusCode.NotFound:
                    return NotFound(response);
                default:
                    return BadRequest(response);

            }

        }

        return Ok(response);
    }

}
