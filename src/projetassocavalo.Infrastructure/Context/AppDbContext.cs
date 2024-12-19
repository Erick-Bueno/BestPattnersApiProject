
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using projetassocavalo.Domain.Entities;
using projetassocavalo.Domain.EntityConfiguration;
using projetassocavalo.Infrastructure.EntityConfigurations;

namespace projetassocavalo.Infrastructure.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<User> users { get; set; }
    public DbSet<Token> tokens { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new TokenConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}