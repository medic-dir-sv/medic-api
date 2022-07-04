using System.Reflection;
using Medic.Services.Abstracts.Repositories;
using Medic.Services.Abstracts.Services;
using Medic.Services.Implementations.Repositories;
using Medic.Services.Implementations.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Medic.Services.Dependencies;

public static class DependencyInjection
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<IAppointmentRepository, AppointmentRepository>();
        services.AddTransient<IPatientRepository, PatientRepository>();
        services.AddTransient<IDoctorRepository, DoctorRepository>();
        services.AddTransient<IAuthRepository, AuthRepository>();
        
        return services;
    }

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddTransient<IAppointmentService, AppointmentService>();
        services.AddTransient<IPatientService, PatientService>();
        services.AddTransient<IDoctorService, DoctorService>();
        services.AddTransient<IAuthService, AuthService>();
        
        return services;
    }
}