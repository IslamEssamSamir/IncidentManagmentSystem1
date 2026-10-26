namespace IncidentManagmentSystem1.API.Core.Constants;

public static class ValidationErrors
{
    public const string MaxLength = "Length cannot be more than {1} characters";
    public const string RequiredField = "{0} is Required Field";
    public const string StringLength = "The {0} must be at least {2} and at max {1} characters long.";
    public const string InvalidRange = "{0} should be between {1} and {2}";

    public const string NotAllowedImageExtensions = "only .png , .jpg , .jpeg extensions are allowed!";
    public const string NotAllowedDocumentExtensions = "only .pdf , .docx , .doc extensions are allowed!";

    public const string MaxAllowedImageSize = "File cant be more than 2MB!";// to path this no from file service
    public const string MaxAllowedDocumentSize = "File cant be more than 2MB!";// to path this no from file service

    public const string NotAllowFutureDate = "Date Cannot be in the future!";

    public const string ConfirmPasswordNotMatch = "The password and confirmation password do not match.";


    public const string OnlyEnglishLetters = "Only English letters are allowed.";
    public const string OnlyArabicLetters = "Only Arabic letters are allowed.";
    public const string OnlyNumbersAndLetters = "Only Arabic/English letters or digits are allowed.";
    public const string DenySpecialCharacters = "Special characters are not allowed.";
    public const string InvalidMobileNumber = "Invalid phone number.";
    public const string InvalidNationalId = "Invalid National ID.";
    public const string InvalidOTP = "Invalid OTP.";
    public const string EmptyImage = "Please select an image.";
    public const string ExistEmail = "This Email Address is already exist";
    public const string ExistNationalId = "This National Id is used already";




    public static string IsExistErrorMessage(string existedItem)
    {
        return $"This {existedItem} is already exist!";
    }


    public static string NotFoundIdMessage(string notExistedItem)
    {
        return $"Their is no {notExistedItem} with this id.";
    }



}

