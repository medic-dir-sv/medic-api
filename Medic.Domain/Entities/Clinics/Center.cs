using Medic.Domain.Entities.Common;

namespace Medic.Domain.Entities.Clinics;

public class Center
{
    public int Id { get; set; }
    
    public string? Name { get; set; }

    public Geolocation? Location { get; set; }
}