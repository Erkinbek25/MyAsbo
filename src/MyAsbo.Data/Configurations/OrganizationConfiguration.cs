using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyAsbo.Domain.Entities;

namespace MyAsbo.Data.Configurations;

public class OrganizationConfiguration : IEntityTypeConfiguration<Organization>
{
    public void Configure(EntityTypeBuilder<Organization> builder)
    {
        builder.Property(o => o.Name).HasMaxLength(200).IsRequired();
        builder.Property(o => o.Inn).HasMaxLength(9).IsRequired();
        builder.Property(o => o.Address).HasMaxLength(500);
        builder.Property(o => o.PhoneNumber).HasMaxLength(20);

        builder.HasIndex(o => o.Inn).IsUnique();

        
    }
}
