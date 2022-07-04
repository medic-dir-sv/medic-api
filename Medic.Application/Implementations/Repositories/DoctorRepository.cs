using Medic.Domain.Entities.Clinics;
using Medic.Domain.Entities.Doctors;
using Medic.Services.Abstracts.Db;
using Medic.Services.Abstracts.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Medic.Services.Implementations.Repositories;

public class DoctorRepository : IDoctorRepository
{
    private readonly IAppDbContext _ctx;

    public DoctorRepository(IAppDbContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<Doctor?> GetById(string id)
    {
        return await _ctx.Doctors.Where(dr => dr.Email!.Equals(id))
            .Include(dr => dr.Clinics)
            .Include(dr => dr.Experience)
            .Include(dr => dr.Formation)
            .Include(dr => dr.Schedule)
            .FirstOrDefaultAsync();
    }

    public IQueryable<Doctor> Get(int page, int limit)
    {
        return _ctx.Doctors.OrderByDescending(dr => dr.Email)
            .Include(dr => dr.Clinics)
            .ThenInclude(cl => cl.Location)
            .Include(dr => dr.Experience)
            .Include(dr => dr.Formation)
            .Include(dr => dr.Schedule)
            .ThenInclude(schedule => schedule.Availability)
            .AsQueryable();
    }

    public async Task<IList<TimeSpan>?> GetAvailability(string id, DateTime date)
    {
        var workDays = await _ctx.Doctors
            .Where(dr => dr.Email!.Equals(id))
            .Include(dr => dr.Schedule)
            .ThenInclude(sc => sc!.Availability)
            .Select(dr => dr.Schedule!.Availability)
            .FirstOrDefaultAsync();
        
        var appointments = await _ctx.Appointments
            .Where(app => app.Doctor!.Email!.Equals(id))
            .Where(app => app.Date.Equals(date))
            .Select(app => app.Date.TimeOfDay)
            .ToListAsync();

        if (workDays is null)
            return null;
        
        var availability = new List<TimeSpan>();

        foreach (var workday in workDays)
        {   
            foreach (var interval in workday.WorkingHours!)
            {
                var startsAt = interval.StartsAt;
                var endsAt = interval.EndsAt;

                if (date.DayOfWeek != workday.Day)
                    return null;

                for (var ts = startsAt; ts <= endsAt; ts = ts.Add(new TimeSpan(00, 30, 0)))
                {
                    if (!appointments.Any(app => new TimeSpan(app.Hours, app.Minutes, 00).Equals(ts)))
                        availability.Add(ts);
                }
            }
        }

        return availability;
    }

    public async Task<Doctor?> UpdateSchedule(string id, Schedule schedule)
    {
        var doctor = await GetById(id);

        if (doctor is null)
            return null;

        doctor.Schedule = schedule;
        
        await _ctx.SaveChangesAsync();
        return doctor;
    }

    public async Task<Doctor?> UpdateFormation(string id, IList<Formation>? formations)
    {
        var doctor = await GetById(id);

        if (doctor is null)
            return null;

        doctor.Formation = formations;

        await _ctx.SaveChangesAsync();
        return doctor;
    }

    public async Task<Doctor?> UpdateExperience(string id, IList<Experience>? experiences)
    {
        var doctor = await GetById(id);

        if (doctor is null)
            return null;

        doctor.Experience = experiences;
        
        await _ctx.SaveChangesAsync();
        return doctor;
    }

    public async Task<Doctor?> UpdateCenters(string id, IList<Center> clinics)
    {
        var doctor = await GetById(id);

        if (doctor is null)
            return null;

        doctor.Clinics = clinics;
        
        await _ctx.SaveChangesAsync();
        return doctor;
    }

    public async Task<Doctor?> UpdateSpecialty(string id, string specialty)
    {
        var doctor = await GetById(id);

        if (doctor is null)
            return null;

        doctor.Specialty = specialty;
        
        await _ctx.SaveChangesAsync();
        return doctor;
    }
}