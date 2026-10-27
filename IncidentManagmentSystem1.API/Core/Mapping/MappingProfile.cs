using AutoMapper;
using IncidentManagmentSystem1.API.Core.DTOs.Account;
using IncidentManagmentSystem1.API.Core.DTOs.Auth;

namespace IncidentManagmentSystem1.API.Core.Mapping;

public class MappingProfile : Profile
{

    public MappingProfile()
    {
        CreateMap<RegisterRequest, ApplicationUser>()

            .ForMember(dest => dest.FirstName,
            opt => opt.MapFrom(src => char.ToUpper(src.FirstName[0]) + src.FirstName.Substring(1).ToLower()))

            .ForMember(dest => dest.LastName,
            opt => opt.MapFrom(src => char.ToUpper(src.LastName[0]) + src.LastName.Substring(1).ToLower()))

            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email));



        CreateMap<ApplicationUser, ProfileResponse>()
             .ForMember(dest => dest.Role, opt => opt.Ignore())
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => Path.Combine(HostingDomain.ApplicationDomain, src.ImageUrl!)));







    }
}
