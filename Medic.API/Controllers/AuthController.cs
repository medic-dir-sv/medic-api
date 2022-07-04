using Medic.API.Extensions;
using Medic.Services.Abstracts.Services;
using Medic.Services.ViewModels;
using Medic.Services.ViewModels.Auth;
using Medic.Services.ViewModels.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Medic.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _service;
    private readonly IConfiguration _configuration;

    public AuthController(IAuthService service, IConfiguration configuration)
    {
        _service = service;
        _configuration = configuration;
    }

    [AllowAnonymous]
    [HttpPost]
    [Route("login")]
    public async Task<ActionResult<BaseIdentityWithTokenVm>> Login(LoginVm loginInfo)
    {
        var token = await _service.LoginAsync(_configuration, loginInfo);

        return Ok(token);
    }

    [AllowAnonymous]
    [HttpPost]
    [Route("register")]
    public async Task<ActionResult<BaseIdentityVm>> Register([FromForm] RegisterVm registerVm)
    {
        var user = await _service.RegisterAsync(registerVm);

        return StatusCode(201, user);
    }
    
    // TODO: Update user info (firstName, lastName, age, phone)
}
