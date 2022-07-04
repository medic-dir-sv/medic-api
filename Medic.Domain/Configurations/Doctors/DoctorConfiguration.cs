using Medic.Domain.Entities.Common;
using Medic.Domain.Entities.Doctors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medic.Domain.Configurations.Doctors;

public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder.Property(d => d.Role).HasDefaultValue(Role.Doctor);
    }
}