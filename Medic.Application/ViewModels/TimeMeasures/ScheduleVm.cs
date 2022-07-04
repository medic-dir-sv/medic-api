namespace Medic.Services.ViewModels.TimeMeasures;

public class ScheduleVm
{
    public int Id { get; set; }
    
    public IList<WorkdayVm>? Availability { get; set; }
}