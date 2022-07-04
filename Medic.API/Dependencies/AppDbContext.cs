using System.Reflection;
using Medic.Domain.Entities.Appointments;
using Medic.Domain.Entities.Clinics;
using Medic.Domain.Entities.Common;
using Medic.Domain.Entities.Doctors;
using Medic.Domain.Entities.Patients;
using Medic.Services.Abstracts.Db;
using Microsoft.EntityFrameworkCore;

namespace Medic.API.Dependencies;

public class AppDbContext : DbContext, IAppDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    
    public DbSet<BaseIdentity> BaseIdentities => Set<BaseIdentity>();
    
    public DbSet<Appointment> Appointments => Set<Appointment>();
    
    public DbSet<Center> Clinics => Set<Center>();

    public DbSet<Patient> Patients => Set<Patient>();
    
    public DbSet<Doctor> Doctors => Set<Doctor>();

    public DbSet<Schedule> Schedules => Set<Schedule>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.Load("Medic.Domain"));
        modelBuilder.HasPostgresExtension("uuid-ossp");
    }
}