namespace IncidentManagmentSystem1.API.Core.DTOs.Auth;

public class RegisterRequest
{
    [Required(ErrorMessage = ValidationErrors.RequiredField)]
    //[RegularExpression(RegexPattern.CharactersOnly_Eng_ForNames, ErrorMessage = ValidationErrors.OnlyEnglishLetters)]
    [StringLength(25, ErrorMessage = ValidationErrors.StringLength, MinimumLength = 2)]
    public string FirstName { get; set; } = null!;
    [Required(ErrorMessage = ValidationErrors.RequiredField)]
    //[RegularExpression(RegexPattern.CharactersOnly_Eng_ForNames, ErrorMessage = ValidationErrors.OnlyEnglishLetters)]
    [StringLength(25, ErrorMessage = ValidationErrors.StringLength, MinimumLength = 2)]
    public string LastName { get; set; } = null!;

    [Required(ErrorMessage = ValidationErrors.RequiredField)]
    [RegularExpression(RegexPattern.MobileNumber, ErrorMessage = ValidationErrors.InvalidMobileNumber)]
    public string PhoneNumber { get; set; } = null!;


    [Required(ErrorMessage = ValidationErrors.RequiredField)]
    [Display(Name = "Email Address")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = ValidationErrors.RequiredField)]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;

    [Required(ErrorMessage = ValidationErrors.RequiredField)]
    [Display(Name = "Confirm Password")]
    [Compare("Password")]
    [DataType(DataType.Password)]
    public string ConfirmPassword { get; set; } = null!;
}
