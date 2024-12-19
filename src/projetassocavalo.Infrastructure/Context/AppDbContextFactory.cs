using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace projetassocavalo.Infrastructure.Context;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var basePath = Path.Combine(Directory.GetCurrentDirectory(), "..", "projetassocavalo.Api");
        var configuration = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.Development.json")
            .Build();

        var connectionString = configuration.GetConnectionString("Default");
        var options = new DbContextOptionsBuilder<AppDbContext>();
        options.UseNpgsql(connectionString, p => p.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName));
        return new AppDbContext(options.Options);
    }
}