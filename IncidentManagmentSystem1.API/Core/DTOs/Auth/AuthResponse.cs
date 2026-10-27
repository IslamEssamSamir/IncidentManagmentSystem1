namespace IncidentManagmentSystem1.API.Core.DTOs.Auth;

public class AuthResponse
{
    public string Id { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Token { get; set; }
    public int ExpireIn { get; set; }

    public IEnumerable<string> Roles { get; set; }
}
