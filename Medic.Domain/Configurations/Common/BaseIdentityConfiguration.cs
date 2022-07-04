using Medic.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medic.Domain.Configurations.Common;

public class BaseIdentityConfiguration : IEntityTypeConfiguration<BaseIdentity>
{
    public void Configure(EntityTypeBuilder<BaseIdentity> builder)
    {
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Role)
            .HasConversion(
                v => v.ToString(),
                v => (Role)Enum.Parse(typeof(Role), v)
            );
        builder.Property(b => b.RecoveryToken)
            .HasColumnType("uuid");
        builder.Property(b => b.ProfileImage).IsRequired(false);
    }
}