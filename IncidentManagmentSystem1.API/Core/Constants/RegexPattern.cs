namespace IncidentManagmentSystem1.API.Core.Constants;

public static class RegexPattern
{
    public const string password = "(?=(.*[0-9]))(?=.*[\\!@#$%^&*()\\\\[\\]{}\\-_+=~`|:;\"'<>,./?])(?=.*[a-z])(?=(.*[A-Z]))(?=(.*)).{8,}";
    public const string username = "^[a-zA-z0-9-._@+]*$";


    public const string CharactersOnly_Eng = "^[a-zA-Z-_ ]*$";
    public const string CharactersOnly_Eng_ForNames = "^[a-zA-Z]*$";
    public const string CharactersOnly_Ar = "^[\u0600-\u065F\u066A-\u06EF\u06FA-\u06FF ]*$";
    public const string NumbersAndChrOnly_ArEng = "^(?=.*[\u0600-\u065F\u066A-\u06EF\u06FA-\u06FFa-zA-Z])[\u0600-\u065F\u066A-\u06EF\u06FA-\u06FFa-zA-Z0-9 _-]+$";
    public const string DenySpecialCharacters = "^[^<>!#%$]*$";
    public const string MobileNumber = "^01[0,1,2,5]{1}[0-9]{8}$";
    public const string NationalId = "^[2,3]{1}[0-9]{13}$";
    public const string NumbersOnly = "^[0-9]{6}$";
    public const string extendedEgyptPhoneNumberRegex = @"^(01[0125]\d{8}|02\d{8}| 03\d{8})$";

}
