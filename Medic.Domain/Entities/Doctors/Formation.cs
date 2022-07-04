namespace Medic.Domain.Entities.Doctors;

public class Formation
{
    public int Id { get; set; }
    
    public string? Title { get; set; }
    
    public string? Location { get; set; }
    
    public DateTime StartedAt { get; set; }
    
    public DateTime EndedAt { get; set; }
}