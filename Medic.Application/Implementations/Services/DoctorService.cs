using AutoMapper;
using AutoMapper.QueryableExtensions;
using Medic.Domain.Entities.Clinics;
using Medic.Domain.Entities.Doctors;
using Medic.Services.Abstracts.Repositories;
using Medic.Services.Abstracts.Services;
using Medic.Services.Exceptions;
using Medic.Services.ViewModels.Clinics;
using Medic.Services.ViewModels.Common;
using Medic.Services.ViewModels.Doctors;
using Medic.Services.ViewModels.TimeMeasures;

namespace Medic.Services.Implementations.Services;

public class DoctorService : IDoctorService
{
    private readonly IDoctorRepository _repository;
    private readonly IMapper _mapper;

    public DoctorService(IDoctorRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<DoctorVm> Get(string id)
    {
        var doctor = await _repository.GetById(id);
        
        if (doctor is null)
            throw new HttpException(404, "Doctor not found");

        return _mapper.Map<Doctor, DoctorVm>(doctor);
    }

    public async Task<IList<AvailabilityVm>> GetAvailability(string id, DateTime date)
    {
        var schedule = await _repository.GetAvailability(id, date);

        if (schedule is null)
            throw new HttpException(204, "No available hours");
        
        return schedule.Select(ts => new AvailabilityVm(date, ts)).ToList();
    }

    public async Task<PaginatedListVm<DoctorVm>> GetAll(int page, int limit)
    {
        var asQueryable = _repository.Get(page, limit);

        var preList = await PaginatedListVm<DoctorVm>.CreateAsyncWithMapping<Doctor>(
            _mapper, asQueryable, page, limit
        );

        return preList;
    }

    public async Task<DoctorVm> UpdateSchedule(string email, ScheduleVm viewModel)
    {
        var doctor = await _repository.UpdateSchedule(
            email,
            _mapper.Map<ScheduleVm, Schedule>(viewModel)
        );
        
        if (doctor is null)
            throw new HttpException(404, "Doctor not found");

        return _mapper.Map<Doctor, DoctorVm>(doctor);
    }

    public async Task<DoctorVm> UpdateFormation(string email, IList<FormationVm> viewModel)
    {
        var doctor = await _repository.UpdateFormation(
            email, _mapper.Map<IList<FormationVm>, IList<Formation>>(viewModel)
        );

        if (doctor is null)
            throw new HttpException(404, "User not found");

        return _mapper.Map<Doctor, DoctorVm>(doctor);
    }

    public async Task<DoctorVm> UpdateExperience(string email, IList<ExperienceVm> viewModel)
    {
        var doctor = await _repository.UpdateExperience(
            email, _mapper.Map<IList<ExperienceVm>, IList<Experience>>(viewModel)
        );

        if (doctor is null)
            throw new HttpException(404, "User not found");

        return _mapper.Map<Doctor, DoctorVm>(doctor);
    }

    public async Task<DoctorVm> UpdateSpecialty(string email, SpecialtyVm viewModel)
    {
        var doctor = await _repository.UpdateSpecialty(
            email, viewModel.Name!
        );

        if (doctor is null)
            throw new HttpException(404, "User not found");

        return _mapper.Map<Doctor, DoctorVm>(doctor);
    }
    
    public async Task<DoctorVm> UpdateClinics(string email, IList<CenterVm> viewModel)
    {
        var doctor = await _repository.UpdateCenters(
            email, _mapper.Map<IList<CenterVm>, IList<Center>>(viewModel)
        );

        if (doctor is null)
            throw new HttpException(404, "User not found");

        return _mapper.Map<Doctor, DoctorVm>(doctor);
    }
}