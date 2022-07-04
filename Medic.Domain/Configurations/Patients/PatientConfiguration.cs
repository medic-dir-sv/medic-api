using Medic.Domain.Entities.Common;
using Medic.Domain.Entities.Patients;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medic.Domain.Configurations.Patients;

public class PatientConfiguration : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.Property(p => p.Role).HasDefaultValue(Role.Patient);
    }
}