using Medic.Services.ViewModels.Appointments;

namespace Medic.Services.Abstracts.Services;

public interface IPatientService
{
    Task<IList<AppointmentVm>> GetMyPastAppointments(string email);
    
    Task<IList<AppointmentVm>> GetMyFutureAppointments(string email);
}