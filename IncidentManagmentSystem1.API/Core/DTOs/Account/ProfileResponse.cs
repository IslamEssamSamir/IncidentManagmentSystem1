namespace IncidentManagmentSystem1.API.Core.DTOs.Account;

public class ProfileResponse
{
    public string Id { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? PhoneNumber { get; set; }
    public string? ImageUrl { get; set; }
    public List<string>? Role { get; set; }
}
