using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MoneyZip.Infrastructure.Data;
using MoneyZip.Infrastructure.Interfaces;
using MoneyZip.Infrastructure.Repositories;
using MoneyZip.Repositories;

namespace MoneyZip.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        // Configure DbContext to use SQLite
        services.AddDbContext<MoneyZipDbContext>(options =>
            options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}