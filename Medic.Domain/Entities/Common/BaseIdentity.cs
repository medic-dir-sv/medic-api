namespace Medic.Domain.Entities.Common;

public class BaseIdentity
{
    public int Id { get; set; }
    
    public string? ProfileImage { get; set; }
    
    public string? Name { get; set; }

    public string? LastName { get; set; }

    public string? Password { get; set; }
    
    public string? Email { get; set; }
    
    public string? Phone { get; set; }
    
    public DateTime DateOfBirth { get; set; }
    
    public Role Role { get; set; }
    
    public Guid RecoveryToken { get; set; }
}