using Microsoft.EntityFrameworkCore;

namespace IncidentManagmentSystem1.API.Core.Models;


[Index(nameof(UserName), IsUnique = true)]
[Index(nameof(Email), IsUnique = true)]
public class ApplicationUser : IdentityUser
{
    [MaxLength(50, ErrorMessage = ValidationErrors.RequiredField)]
    public string FirstName { get; set; } = null!;
    [MaxLength(50, ErrorMessage = ValidationErrors.RequiredField)]
    public string LastName { get; set; } = null!;


    public string? ImageUrl { get; set; }


    public bool IsDeleted { get; set; }

    public DateTime CreatedOn { get; set; } = DateTime.Now;
    public DateTime? LastUpdatedOn { get; set; } = null;


    public string? CreatedById { get; set; }

    public string? UpdatedById { get; set; }




}
