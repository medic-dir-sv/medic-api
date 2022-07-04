using Medic.Domain.Entities.Appointments;
using Medic.Domain.Entities.Clinics;
using Medic.Domain.Entities.Common;
using Medic.Domain.Entities.Doctors;
using Medic.Domain.Entities.Patients;
using Microsoft.EntityFrameworkCore;

namespace Medic.Services.Abstracts.Db;

public interface IAppDbContext
{
    DbSet<Appointment> Appointments { get; }
    
    DbSet<BaseIdentity> BaseIdentities { get; }
    
    DbSet<Patient> Patients { get; }
    
    DbSet<Doctor> Doctors { get; }
    
    DbSet<Center> Clinics { get; }
    
    DbSet<Schedule> Schedules { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}