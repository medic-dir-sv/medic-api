using Medic.Services.Abstracts.Repositories;
using Medic.Services.Abstracts.Services;
using Medic.Services.ViewModels.Appointments;

namespace Medic.Services.Implementations.Services;

public class PatientService : IPatientService
{
    private readonly IPatientRepository _repository;

    public PatientService(IPatientRepository repository)
    {
        _repository = repository;
    }

    public async Task<IList<AppointmentVm>> GetMyPastAppointments(string email)
    {
        throw new NotImplementedException();
    }

    public async Task<IList<AppointmentVm>> GetMyFutureAppointments(string email)
    {
        throw new NotImplementedException();
    }
}