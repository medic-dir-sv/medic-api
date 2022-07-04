namespace Medic.Services.ViewModels.Appointments;

public record CreateAppointmentVm(string DoctorId, int CenterId, DateTime Date);