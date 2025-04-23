using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MoneyZip.Infrastructure;
using MoneyZip.Application.UseCases;
using MoneyZip.Application.UseCases.Common;
using MoneyZip.Application.UseCases.Users;

namespace MoneyZip.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Add infrastructure services (DbContext, repositories, external services)
        services.AddInfrastructureServices(configuration);

        // Register use cases
        // services.AddScoped<MoneyTransferUseCase>();
        services.AddScoped<CreateUserUseCase>();
        services.AddScoped<GetUserUseCase>();
        services.AddScoped<UpdateUserUseCase>();
        services.AddScoped<DeleteUserUseCase>();
        services.AddScoped<ListUsersUseCase>();

        return services;
    }
}