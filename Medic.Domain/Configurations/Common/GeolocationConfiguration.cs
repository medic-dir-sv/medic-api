using Medic.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medic.Domain.Configurations.Common;

public class GeolocationConfiguration : IEntityTypeConfiguration<Geolocation>
{
    public void Configure(EntityTypeBuilder<Geolocation> builder)
    {
        
    }
}