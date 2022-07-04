using AutoMapper;
using Medic.Domain.Entities.Common;
using Medic.Services.ViewModels.Auth;
using Medic.Services.ViewModels.Common;

namespace Medic.Services.Mappings.Common;

public class BaseIdentityMappings : Profile
{
    public BaseIdentityMappings()
    {
        CreateMap<BaseIdentity, BaseIdentityVm>()
            .ForMember(dest => dest.FullName,
                opt =>
                    opt.MapFrom(src => $"{src.Name} {src.LastName}"))
            .ForMember(dest => dest.Age,
                opt => 
                    opt.MapFrom(src => DateTime.Now.Year - src.DateOfBirth.Year));
        
        CreateMap<BaseIdentity, BaseIdentityWithTokenVm>()
            .ForMember(dest => dest.FullName,
                opt =>
                    opt.MapFrom(src => $"{src.Name} {src.LastName}"))
            .ForMember(dest => dest.Age,
                opt => 
                    opt.MapFrom(src => Math.Floor(
                        (DateTime.Now - src.DateOfBirth).TotalDays / 365.25))
                    );

        CreateMap<RegisterVm, BaseIdentity>();
    }
}