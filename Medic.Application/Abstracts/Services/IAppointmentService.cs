using Medic.Services.ViewModels;
using Medic.Services.ViewModels.Appointments;

namespace Medic.Services.Abstracts.Services;

public interface IAppointmentService
{
    Task<AppointmentVm> GetyById(int aptId);
    
    Task<AppointmentVm> CreateAppointment(string id, CreateAppointmentVm viewModel);
    
    Task<IList<AppointmentVm>> MyAppointments(string patientId);

    Task<IList<AppointmentVm>> MyAppointmentsAsDoctor(string doctorId);

    Task<AppointmentVm?> AcceptAppointment(int id);

    Task<bool> DeleteAppointment(int id);

    Task<AppointmentVm?> UpdateAppointment(int id, UpdateAppointmentVm viewModel);
}