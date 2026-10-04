using Integrations.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Integrations.Api.Data.Configurations;

public class PolicyConfiguration : IEntityTypeConfiguration<Policy>
{
    public void Configure(EntityTypeBuilder<Policy> builder)
    {
        builder.HasKey(policy => policy.Id);

        builder.Property(policy => policy.PolicyNumber)
            .HasMaxLength(32)
            .IsRequired();

        builder.HasIndex(policy => policy.PolicyNumber)
            .IsUnique();

        builder.Property(policy => policy.HolderName)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(policy => policy.Premium)
            .HasPrecision(18, 2);

        builder.Property(policy => policy.EffectiveDate)
            .IsRequired();

        builder.HasData(
            new Policy
            {
                Id = 1,
                PolicyNumber = "POL-1001",
                HolderName = "Nino Beridze",
                Premium = 1250.00m,
                EffectiveDate = new DateOnly(2026, 1, 1)
            },
            new Policy
            {
                Id = 2,
                PolicyNumber = "POL-1002",
                HolderName = "Giorgi Maisuradze",
                Premium = 980.50m,
                EffectiveDate = new DateOnly(2026, 2, 15)
            },
            new Policy
            {
                Id = 3,
                PolicyNumber = "POL-1003",
                HolderName = "Mariam Kapanadze",
                Premium = 1430.75m,
                EffectiveDate = new DateOnly(2026, 3, 10)
            });
    }
}
