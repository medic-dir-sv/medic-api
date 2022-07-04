namespace Medic.Domain.Entities.TimeMeasures;

public class Workday
{
    public int Id { get; set; }
    
    public DayOfWeek Day { get; set; }
    
    public IList<TimeInterval>? WorkingHours { get; set; }
}