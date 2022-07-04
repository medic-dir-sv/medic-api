namespace Medic.Domain.Entities.TimeMeasures;

public class TimeInterval
{
    public int Id { get; set; }
    
    public TimeSpan StartsAt { get; set; }
    
    public TimeSpan EndsAt { get; set; }

    public override string ToString()
    {
        return $"{StartsAt}-{EndsAt}";
    }

    protected bool Equals(TimeInterval other)
    {
        return Id == other.Id && StartsAt.Equals(other.StartsAt) && EndsAt.Equals(other.EndsAt);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, StartsAt, EndsAt);
    }
}