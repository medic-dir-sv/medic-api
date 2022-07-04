namespace Medic.Services.ViewModels.TimeMeasures;

public class WorkdayVm
{
    public DayOfWeek Day { get; set; }
    
    public IList<TimeIntervalVm>? WorkingHours { get; set; }
}