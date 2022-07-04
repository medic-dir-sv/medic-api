using Medic.Domain.Entities.Appointments;
using Medic.Domain.Entities.Clinics;

namespace Medic.Services.Abstracts.Repositories;

public interface IAppointmentRepository
{
    Task<IList<Appointment>> MyAppointments(string patientId);

    Task<IList<Appointment>> MyAppointmentsAsDoctor(string doctorId);

    Task<Appointment?> AcceptAppointment(int id);

    Task<bool> DeleteAppointment(int id);

    Task<Appointment?> UpdateAppointment(int id, DateTime? date, int? clinicId);
    
    Task<Appointment?> CreateAppointment(string patientId, string doctorId, int centerId, DateTime date);
}