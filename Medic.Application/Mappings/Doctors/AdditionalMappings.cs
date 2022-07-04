using AutoMapper;
using Medic.Domain.Entities.Clinics;
using Medic.Domain.Entities.Doctors;
using Medic.Services.ViewModels.Clinics;
using Medic.Services.ViewModels.Doctors;

namespace Medic.Services.Mappings.Doctors;

public class AdditionalMappings : Profile
{
    public AdditionalMappings()
    {
        CreateMap<Formation, FormationVm>();
        CreateMap<FormationVm, Formation>();
        
        CreateMap<Center, CenterVm>();
        CreateMap<CenterVm, Center>();
        
        CreateMap<Specialty, SpecialtyVm>();
        CreateMap<SpecialtyVm, Specialty>();
        
        CreateMap<Experience, ExperienceVm>();
        CreateMap<ExperienceVm, Experience>();
    }    
}