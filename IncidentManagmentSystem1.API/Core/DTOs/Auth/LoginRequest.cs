namespace IncidentManagmentSystem1.API.Core.DTOs.Auth;

public class LoginRequest
{

    [Length(5 , 100 , ErrorMessage = ValidationErrors.StringLength)]
    [EmailAddress]
    public string Email { get; set; } = null!;

    [Length(8, 100, ErrorMessage = ValidationErrors.StringLength)]
    public string Password { get; set; } = null!;
}
