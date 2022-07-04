using Medic.Domain.Entities.Common;

namespace Medic.Services.ViewModels.Common;

public class BaseIdentityVm
{
    public string? ProfileImage { get; set; }

    public DateTime DateOfBirth { get; set; }
    public string? FullName { get; set; }

    public string? Email { get; set; }
    
    public string? Phone { get; set; }

    public int? Age { get; set; }
    
    public Role? Role { get; set; }
}