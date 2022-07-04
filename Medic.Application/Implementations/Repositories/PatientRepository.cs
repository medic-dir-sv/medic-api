using Medic.Domain.Entities.Appointments;
using Medic.Services.Abstracts.Db;
using Medic.Services.Abstracts.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Medic.Services.Implementations.Repositories;

public class PatientRepository : IPatientRepository
{
    private readonly IAppDbContext _ctx;

    public PatientRepository(IAppDbContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<IList<Appointment>> GetMyFutureAppointments(string email)
    {
        return await _ctx.Appointments
            .Where(ap => ap.Patient!.Email!.Equals(email))
            .Where(ap => ap.Date > DateTime.Now)
            .ToListAsync();
    }

    public async Task<IList<Appointment>> GetMyPastAppointments(string email)
    {
        return await _ctx.Appointments
            .Where(ap => ap.Patient!.Email!.Equals(email))
            .Where(ap => ap.Date < DateTime.Now)
            .ToListAsync();
    }

    public async Task<IList<Appointment>> CreateAppointment(string email)
    {
        throw new NotImplementedException();
    }
}