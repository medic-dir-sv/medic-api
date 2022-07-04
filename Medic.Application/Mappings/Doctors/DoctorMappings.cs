using AutoMapper;
using Medic.Domain.Entities.Doctors;
using Medic.Services.ViewModels.Doctors;

namespace Medic.Services.Mappings.Doctors;

public class DoctorMappings : Profile
{
    public DoctorMappings()
    {
        CreateMap<Doctor, DoctorVm>()
            .ForMember(dest => dest.FullName,
                opt =>
                    opt.MapFrom(src => $"{src.Name} {src.LastName}"))
            .ForMember(dest => dest.Age,
                opt => 
                    opt.MapFrom(src => DateTime.Now.Year - src.DateOfBirth.Year));
        
        CreateMap<DoctorVm, Doctor>();
    }
}