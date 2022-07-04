using Medic.Domain.Entities.Appointments;

namespace Medic.Services.Abstracts.Repositories;

public interface IPatientRepository
{
    Task<IList<Appointment>> GetMyFutureAppointments(string email);

    Task<IList<Appointment>> GetMyPastAppointments(string email);

    Task<IList<Appointment>> CreateAppointment(string email);
}