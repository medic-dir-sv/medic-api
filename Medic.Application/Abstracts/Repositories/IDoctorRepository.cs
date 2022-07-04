using Medic.Domain.Entities.Clinics;
using Medic.Domain.Entities.Doctors;

namespace Medic.Services.Abstracts.Repositories;

public interface IDoctorRepository
{
    Task<Doctor?> GetById(string id);
    
    IQueryable<Doctor> Get(int page, int limit);

    Task<IList<TimeSpan>?> GetAvailability(string id, DateTime date);

    Task<Doctor?> UpdateSchedule(string id, Schedule schedule);

    Task<Doctor?> UpdateFormation(string id, IList<Formation> formations);

    Task<Doctor?> UpdateExperience(string id, IList<Experience>? experiences);

    Task<Doctor?> UpdateCenters(string id, IList<Center> clinics);
    
    Task<Doctor?> UpdateSpecialty(string id, string specialty);
}