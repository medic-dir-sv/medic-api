using Medic.Domain.Entities.Clinics;
using Medic.Domain.Entities.Common;

namespace Medic.Domain.Entities.Doctors;

public class Doctor : BaseIdentity
{
    public string? Specialty { get; set; }
    
    public IList<Center>? Clinics { get; set; }
    
    public IList<Formation>? Formation { get; set; }
    
    public IList<Experience>? Experience { get; set; }
    
    public Schedule? Schedule { get; set; }
}