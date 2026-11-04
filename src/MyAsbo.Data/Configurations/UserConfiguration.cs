using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyAsbo.Domain.Entities;

namespace MyAsbo.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(u => u.FirstName).HasMaxLength(100).IsRequired();
        builder.Property(u => u.LastName).HasMaxLength(100).IsRequired();
        builder.Property(u => u.Login).HasMaxLength(50).IsRequired();
        builder.Property(u => u.PhoneNumber).HasMaxLength(20);
        builder.Property(u => u.PasswordHash).IsRequired();
        builder.Property(u => u.Role).HasConversion<string>().HasMaxLength(30);
       
        builder.HasIndex(u => u.Login).IsUnique();

        builder.HasOne(u => u.Organization)
            .WithMany(u => u.Users)
            .HasForeignKey(u => u.Organization)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
