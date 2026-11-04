using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyAsbo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAsbo.Data.Configurations;

public class OrganizationConfiguration : IEntityTypeConfiguration<Organization>
{
    public void Configure(EntityTypeBuilder<Organization> builder)
    {
        builder.Property(o => o.Name).HasMaxLength(100).IsRequired();
        builder.Property(o => o.Inn).HasMaxLength(9).IsRequired();
        builder.Property(o => o.Address).HasMaxLength(500);
        builder.Property(o => o.PhoneNumber).HasMaxLength(20);

        builder.HasIndex(u => u.Inn).IsUnique();

        
    }
}
