using Medic.Domain.Entities.Common;
using Microsoft.AspNetCore.Http;

namespace Medic.Services.ViewModels.Auth;

public class RegisterVm
{
    public IFormFile? Img { get; set; }

    public string? Name { get; set; }
    
    public string? LastName { get; set; }
    
    public string? Password { get; set; }
    
    public string? Email { get; set; }
    
    public string? Phone { get; set; }
    
    public DateTime DateOfBirth { get; set; }
    
    public Role? Role { get; set; }
}