using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using projetassocavalo.Domain.Entities;

namespace projetassocavalo.Infrastructure.EntityConfigurations;

public class TokenConfiguration : IEntityTypeConfiguration<Token>
{
    public void Configure(EntityTypeBuilder<Token> builder)
    {
        builder.HasIndex(t => t.Email);
        builder.Property(t => t.Email).IsRequired().HasMaxLength(300);
    }
}
