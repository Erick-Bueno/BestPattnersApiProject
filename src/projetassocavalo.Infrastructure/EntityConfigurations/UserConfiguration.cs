using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using projetassocavalo.Domain.Entities;

namespace projetassocavalo.Domain.EntityConfiguration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(u => u.Email).IsRequired().HasMaxLength(300);
        builder.HasIndex(u => u.Email);
        builder.Property(u => u.Username).IsRequired();
    }
}