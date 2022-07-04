using Medic.Services.ViewModels.Clinics;
using Medic.Services.ViewModels.Common;
using Medic.Services.ViewModels.Doctors;

namespace Medic.Services.ViewModels.Appointments;

public class AppointmentVm
{
    public int Id { get; set; }
    
    public DateTime Date { get; set; }

    public DoctorVm? Doctor { get; set; }
    
    public CenterVm? Clinic { get; set; }
    
    public bool IsAccepted { get; set; }
}