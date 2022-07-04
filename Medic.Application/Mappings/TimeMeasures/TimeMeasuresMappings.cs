using AutoMapper;
using Medic.Domain.Entities.Doctors;
using Medic.Domain.Entities.TimeMeasures;
using Medic.Services.ViewModels.TimeMeasures;

namespace Medic.Services.Mappings.TimeMeasures;

public class TimeMeasuresMappings : Profile
{
    public TimeMeasuresMappings()
    {
        CreateMap<Schedule, ScheduleVm>();
        CreateMap<ScheduleVm, Schedule>();
        
        CreateMap<Workday, WorkdayVm>();
        CreateMap<WorkdayVm, Workday>();
        
        CreateMap<TimeInterval, TimeIntervalVm>();
        CreateMap<TimeIntervalVm, TimeInterval>();
    }
}