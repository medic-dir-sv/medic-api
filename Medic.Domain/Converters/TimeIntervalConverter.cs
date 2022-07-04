using Medic.Domain.Entities.TimeMeasures;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Medic.Domain.Converters;

public class TimeIntervalConverter : ValueConverter<IList<TimeInterval>?, string?>
{
    public TimeIntervalConverter() : base(le => TimeIntervalListToString(le),
        s => StringToTimeIntervalList(s))
    {
    }

    private static string? TimeIntervalListToString(IList<TimeInterval>? value)
    {
        if (value is null || !value.Any())
            return null;

        return String.Join(",", value);
    }

    private static IList<TimeInterval>? StringToTimeIntervalList(string? value)
    {
        if (value is null || value == string.Empty)
            return null;

        return value.Split(',').Select(i =>
        {
            var intervals = i.Split('-');

            return new TimeInterval
            {
                StartsAt = TimeSpan.Parse(intervals[0]),
                EndsAt = TimeSpan.Parse(intervals[1])
            };
        }).ToList();
    }
}