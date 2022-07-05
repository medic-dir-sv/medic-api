using AutoMapper;
using Medic.Domain.Entities.Appointments;
using Medic.Services.Abstracts.Repositories;
using Medic.Services.Abstracts.Services;
using Medic.Services.Exceptions;
using Medic.Services.ViewModels;
using Medic.Services.ViewModels.Appointments;

namespace Medic.Services.Implementations.Services;

public class AppointmentService : IAppointmentService
{
    private readonly IAppointmentRepository _repository;
    private readonly IMapper _mapper;

    public AppointmentService(IAppointmentRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<AppointmentVm> GetyById(int aptId)
    {
        var app = await _repository.GetById(aptId);

        if (app is null)
            throw new HttpException(404, "Cita no encontrada");

        return _mapper.Map<Appointment, AppointmentVm>(app);
    }

    public async Task<AppointmentVm> CreateAppointment(string id, CreateAppointmentVm viewModel)
    {
        var appointment = await _repository.CreateAppointment(
            id, viewModel.DoctorId, viewModel.CenterId, viewModel.Date
            );
        
        if (appointment is null)
            throw new HttpException(400, "No fue posible crear la cita");

        return _mapper.Map<Appointment, AppointmentVm>(appointment);
    }

    public async Task<IList<AppointmentVm>> MyAppointments(string patientId)
    {
        var appointments = await _repository.MyAppointments(patientId);

        return _mapper.Map<IList<Appointment>, IList<AppointmentVm>>(appointments);
    }

    public async Task<IList<AppointmentVm>> MyAppointmentsAsDoctor(string doctorId)
    {
        var appointments = await _repository.MyAppointmentsAsDoctor(doctorId);

        return _mapper.Map<IList<Appointment>, IList<AppointmentVm>>(appointments);
    }

    public async Task<AppointmentVm?> AcceptAppointment(int id)
    {
        var appointment = await _repository.AcceptAppointment(id);

        if (appointment is null)
            throw new HttpException(404, "Cita no encontrada");

        return _mapper.Map<Appointment, AppointmentVm>(appointment);
    }

    public async Task<bool> DeleteAppointment(int id)
    {
        var deleted = await _repository.DeleteAppointment(id);

        return deleted;
    }

    public async Task<AppointmentVm?> UpdateAppointment(int id, UpdateAppointmentVm viewModel)
    {
        var appointmentUpdated = await _repository.UpdateAppointment(
            id, viewModel.Date, viewModel.ClinicId
        );

        if (appointmentUpdated is null)
            throw new HttpException(404, "Cita no encontrada");

        return _mapper.Map<Appointment, AppointmentVm>(appointmentUpdated);
    }
}