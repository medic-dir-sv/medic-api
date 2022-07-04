using AutoMapper;
using Medic.Domain.Entities.Appointments;
using Medic.Services.ViewModels.Appointments;

namespace Medic.Services.Mappings.Appointments;

public class AppointmentMappings : Profile
{
    public AppointmentMappings()
    {
        CreateMap<Appointment, AppointmentVm>();
        
        // .ForMember(dest => dest.Patient,
        //     opt => opt.MapFrom(src => ap));

        // CreateMap<BaseIdentity, BaseIdentityVm>()
        //     .ForMember(dest => dest.FullName,
        //         opt =>
        //             opt.MapFrom(src => $"{src.Name} {src.LastName}"))
        //     .ForMember(dest => dest.Age,
        //         opt => 
        //             opt.MapFrom(src => DateTime.Now.Year - src.DateOfBirth.Year));

        // var serializedParent = JsonConvert.SerializeObject(identity);
        // user = _ctx.Doctors.Add(JsonConvert.DeserializeObject<Doctor>(serializedParent)!).Entity;
    }
}