using Medic.Domain.Entities.Clinics;
using Medic.Domain.Entities.Doctors;
using Medic.Services.ViewModels.Clinics;
using Medic.Services.ViewModels.Common;
using Medic.Services.ViewModels.TimeMeasures;

namespace Medic.Services.ViewModels.Doctors;

public class DoctorVm : BaseIdentityVm
{
    public string? Specialty { get; set; }
    
    public IList<CenterVm>? Clinics { get; set; }
    
    public IList<FormationVm>? Formation { get; set; }
    
    public IList<ExperienceVm>? Experience { get; set; }
    
    public ScheduleVm? Schedule { get; set; }
}