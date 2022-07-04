using Medic.Services.ViewModels.Clinics;
using Medic.Services.ViewModels.Common;
using Medic.Services.ViewModels.Doctors;
using Medic.Services.ViewModels.TimeMeasures;

namespace Medic.Services.Abstracts.Services;

public interface IDoctorService
{
    Task<DoctorVm> Get(string id);

    Task<IList<AvailabilityVm>> GetAvailability(string id, DateTime date);
    
    Task<PaginatedListVm<DoctorVm>> GetAll (int page, int limit);

    Task<DoctorVm> UpdateSchedule(string email, ScheduleVm viewModel);
    
    Task<DoctorVm> UpdateFormation(string email, IList<FormationVm> viewModel);
    
    Task<DoctorVm> UpdateExperience(string email, IList<ExperienceVm> viewModel);
    
    Task<DoctorVm> UpdateSpecialty(string email, SpecialtyVm viewModel);
    
    Task<DoctorVm> UpdateClinics(string email, IList<CenterVm> viewModel);
}