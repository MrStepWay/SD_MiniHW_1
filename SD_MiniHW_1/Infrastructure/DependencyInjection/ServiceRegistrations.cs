using Microsoft.Extensions.DependencyInjection;
using SD_MiniHW_1.Domain.Services;


namespace SD_MiniHW_1.Infrastructure.DependencyInjection;

public static class ServiceRegistrations
{
    public static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        services.AddSingleton<ZooService>();
        services.AddSingleton<VeterinaryClinic>();
        return services;
    }
}