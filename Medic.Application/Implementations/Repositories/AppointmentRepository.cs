using Medic.Domain.Entities.Appointments;
using Medic.Domain.Entities.Clinics;
using Medic.Services.Abstracts.Db;
using Medic.Services.Abstracts.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Medic.Services.Implementations.Repositories;

public class AppointmentRepository : IAppointmentRepository
{
    private readonly IAppDbContext _ctx;

    public AppointmentRepository(IAppDbContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<Appointment?> GetById(int aptId)
    {
        return await _ctx.Appointments
            .Where(apt => apt.Id == aptId)
            .Include(apt => apt.Clinic)
            .ThenInclude(ct => ct.Location)
            .Include(apt => apt.Doctor)
            .FirstOrDefaultAsync();
    }

    public async Task<IList<Appointment>> MyAppointments(string patientId)
    {
        return await _ctx.Appointments
            .Where(pt => pt.Patient!.Email!.Equals(patientId))
            .Include(apt => apt.Clinic)
            .Include(apt => apt.Doctor)
            .ToListAsync();
    }

    public async Task<IList<Appointment>> MyAppointmentsAsDoctor(string doctorId)
    {
        return await _ctx.Appointments
            .Where(pt => pt.Doctor!.Email!.Equals(doctorId))
            .Include(apt => apt.Clinic)
            .Include(apt => apt.Doctor)
            .ToListAsync();
    }

    public async Task<Appointment?> AcceptAppointment(int id)
    {
        var app = await _ctx.Appointments.Where(apt => apt.Id == id).FirstOrDefaultAsync();

        if (app is null) return null;
        
        app.IsAccepted = true;
        await _ctx.SaveChangesAsync();

        return app;
    }

    public async Task<bool> DeleteAppointment(int id)
    {
        var app = await _ctx.Appointments.Where(apt => apt.Id == id).FirstOrDefaultAsync();

        if (app is null) return false;
        
        var removed = _ctx.Appointments.Remove(app).Entity;

        await _ctx.SaveChangesAsync();

        return true;
    }

    public async Task<Appointment?> UpdateAppointment(int id, DateTime? date, int? clinicId)
    {
        var app = await _ctx.Appointments.Where(apt => apt.Id == id).FirstOrDefaultAsync();

        if (app is null) return null;

        app.Date = date ?? app.Date;

        if (clinicId is not null)
        {
            var clinic = await _ctx.Clinics.Where(cl => cl.Id == clinicId).FirstOrDefaultAsync();
            app.Clinic = clinic ?? app.Clinic;
        }

        await _ctx.SaveChangesAsync();
        return app;
    }

    public async Task<Appointment?> CreateAppointment(string patientId, string doctorId, int centerId, DateTime date)
    {
        var patient = await _ctx.Patients.Where(pt => pt.Email!.Equals(patientId)).FirstOrDefaultAsync();
        var doctor = await _ctx.Doctors.Where(dr => dr.Email!.Equals(doctorId)).FirstOrDefaultAsync();
        var clinic = await _ctx.Clinics
            .Where(cl => cl.Id == centerId)
            .Include(cl => cl.Location)
            .FirstOrDefaultAsync();

        if (patient is null || doctor is null || clinic is null)
            return null;

        var appointment = _ctx.Appointments.Add(new Appointment()
        {
            Patient = patient,
            Date = date,
            Doctor = doctor,
            Clinic = clinic
        }).Entity;

        await _ctx.SaveChangesAsync();

        return appointment;
    }
}