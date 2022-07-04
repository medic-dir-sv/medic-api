using Medic.API.Extensions;
using Medic.Services.Abstracts.Services;
using Medic.Services.ViewModels.Clinics;
using Medic.Services.ViewModels.Common;
using Medic.Services.ViewModels.Doctors;
using Medic.Services.ViewModels.TimeMeasures;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Medic.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DoctorController : ControllerBase
{
    private readonly IDoctorService _service;

    public DoctorController(IDoctorService service)
    {
        _service = service;
    }
    
    [Authorize(Roles = "Patient")]
    [HttpGet("{id}")]
    public async Task<ActionResult<DoctorVm>> GetById(string id)
    {
        var dr = await _service.Get(id);

        return Ok(dr);
    }

    [Authorize(Roles = "Patient")]
    [HttpGet("{id}/availability")]
    public async Task<ActionResult<IList<AvailabilityVm>>> GetDoctorAvailability(string id, [FromQuery] DateTime date)
    {
        var schedules = await _service.GetAvailability(id, date);

        return Ok(schedules);
    }

    [Authorize(Roles = "Patient,Doctor")]
    [HttpGet("all")]
    public async Task<ActionResult<PaginatedListVm<DoctorVm>>> RegisteredDoctors(
        [FromQuery] int page = 1, [FromQuery] int limit = 10
    )
    {
        var drs = await _service.GetAll(page, limit);

        return Ok(drs);
    }
    
    [Authorize(Roles = "Doctor")]
    [HttpPatch]
    [Route("update/schedule")]
    public async Task<DoctorVm> UpdateSchedule(ScheduleVm viewModel)
    {
        var email = User.GetEmail();
        var doctor = await _service.UpdateSchedule(email, viewModel);

        return doctor;
    }

    [Authorize(Roles = "Doctor")]
    [HttpPatch]
    [Route("update/formation")]
    public async Task<DoctorVm> UpdateFormation(IList<FormationVm> viewModel)
    {
        var email = User.GetEmail();
        var doctor = await _service.UpdateFormation(email, viewModel);

        return doctor;
    }
    
    [Authorize(Roles = "Doctor")]
    [HttpPatch]
    [Route("update/experience")]
    public async Task<DoctorVm> UpdateExperience(IList<ExperienceVm> viewModel)
    {
        var email = User.GetEmail();
        var doctor = await _service.UpdateExperience(email, viewModel);

        return doctor;
    }
    
    [Authorize(Roles = "Doctor")]
    [HttpPatch]
    [Route("update/specialty")]
    public async Task<DoctorVm> UpdateSpecialty(SpecialtyVm viewModel)
    {
        var email = User.GetEmail();
        var doctor = await _service.UpdateSpecialty(email, viewModel);

        return doctor;
    }
    
    [Authorize(Roles = "Doctor")]
    [HttpPatch]
    [Route("update/clinics")]
    public async Task<DoctorVm> UpdateCenter(IList<CenterVm> viewModel)
    {
        var email = User.GetEmail();
        var doctor = await _service.UpdateClinics(email, viewModel);

        return doctor;
    }
}
