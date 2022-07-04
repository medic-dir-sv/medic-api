using Medic.Domain.Converters;
using Medic.Domain.Entities.Doctors;
using Medic.Domain.Entities.TimeMeasures;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medic.Domain.Configurations.TimeMeasures;

public class TimeMeasureConfiguration : IEntityTypeConfiguration<TimeInterval>, IEntityTypeConfiguration<Workday>, IEntityTypeConfiguration<Schedule>
{
    public void Configure(EntityTypeBuilder<TimeInterval> builder)
    {
        
    }

    public void Configure(EntityTypeBuilder<Workday> builder)
    {
        var timeIntervalConverter = new TimeIntervalConverter();
        
        builder.Property(b => b.Day)
            .HasConversion<string>();
        
        var valueComparer = new ValueComparer<IList<TimeInterval>>(
            (c1, c2) => c2 != null && c1 != null && c1.SequenceEqual(c2),
            c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
            c => c.ToList());

        builder.Property(b => b.WorkingHours)
            .HasConversion(timeIntervalConverter, valueComparer);
    }

    public void Configure(EntityTypeBuilder<Schedule> builder)
    {
        builder.HasKey(sch => sch.Id);
    }
}