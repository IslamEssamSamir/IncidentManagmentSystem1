namespace IncidentManagmentSystem1.API.Core.DTOs.Account;

public class EditUserProfileRequest
{

    [Required(ErrorMessage = ValidationErrors.RequiredField)]
    //[RegularExpression(RegexPattern.CharactersOnly_Eng_ForNames, ErrorMessage = ValidationErrors.OnlyEnglishLetters)]
    [StringLength(25, ErrorMessage = ValidationErrors.StringLength, MinimumLength = 2)]
    public string FirstName { get; set; } = null!;
    [Required(ErrorMessage = ValidationErrors.RequiredField)]
    //[RegularExpression(RegexPattern.CharactersOnly_Eng_ForNames, ErrorMessage = ValidationErrors.OnlyEnglishLetters)]
    [StringLength(25, ErrorMessage = ValidationErrors.StringLength, MinimumLength = 2)]
    public string LastName { get; set; } = null!;

    public IFormFile? Image { get; set; }

    [Required(ErrorMessage = ValidationErrors.RequiredField)]
    [RegularExpression(RegexPattern.MobileNumber, ErrorMessage = ValidationErrors.InvalidMobileNumber)]
    public string? PhoneNumber { get; set; }

}
