using Medic.API.Extensions;
using Medic.Services.Abstracts.Services;
using Medic.Services.ViewModels;
using Medic.Services.ViewModels.Appointments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Medic.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class AppointmentController : ControllerBase
{
    private readonly IAppointmentService _service;

    public AppointmentController(IAppointmentService service)
    {
        _service = service;
    }

    [Authorize(Roles = "Patient")]
    [HttpPost]
    [Route("new")]
    public async Task<ActionResult<AppointmentVm>> CreateAppointment(CreateAppointmentVm viewModel)
    {
        var email = User.GetEmail();
        return StatusCode(201, await _service.CreateAppointment(email, viewModel));
    }

    [Authorize(Roles = "Patient")]
    [HttpGet]
    [Route("mine")]
    public async Task<ActionResult<IList<AppointmentVm>>> GetMyAppointments()
    {
        var email = User.GetEmail();
        var apts = await _service.MyAppointments(email);

        return Ok(apts);
    }
    
    [Authorize(Roles = "Patient")]
    [HttpGet]
    [Route("mine/{id}")]
    public async Task<ActionResult<IList<AppointmentVm>>> GetMyAppointmentById(int id)
    {
        var apt = await _service.GetyById(id);

        return Ok(apt);
    }
    
    [Authorize(Roles = "Doctor")]
    [HttpGet]
    [Route("doctor/mine")]
    public async Task<ActionResult<IList<AppointmentVm>>> GetMyAppointmentsAsDoctor()
    {
        var email = User.GetEmail();
        var apts = await _service.MyAppointmentsAsDoctor(email);

        return Ok(apts);
    }
    
    [Authorize(Roles = "Doctor")]
    [HttpPatch]
    [Route("accept/{id}")]
    public async Task<ActionResult<IList<AppointmentVm>>> AcceptAppointment(int id)
    {
        var apts = await _service.AcceptAppointment(id);

        return Ok(apts);
    }
    
    [Authorize(Roles = "Patient")]
    [HttpGet]
    [Route("delete/{id}")]
    public async Task<ActionResult<IList<AppointmentVm>>> DeleteAppointment(int id)
    {
        var apts = await _service.DeleteAppointment(id);

        return Ok(apts);
    }
    
    [Authorize(Roles = "Patient")]
    [HttpPatch]
    [Route("update/{id}")]
    public async Task<ActionResult<IList<AppointmentVm>>> UpdateAppointment(int id, [FromBody] UpdateAppointmentVm viewModel)
    {
        var apts = await _service.UpdateAppointment(id, viewModel);

        return Ok(apts);
    }
}