using Medic.Domain.Entities.TimeMeasures;

namespace Medic.Domain.Entities.Doctors;

public class Schedule
{
    public int Id { get; set; }
    
    public IList<Workday>? Availability { get; set; }
}