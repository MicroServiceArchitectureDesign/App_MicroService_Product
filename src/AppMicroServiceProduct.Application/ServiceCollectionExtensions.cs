using AppMicroServiceBuildingBlock.Contract.ApplicationContracts.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace AppMicroServiceProduct.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services
            .AddBuildingBlockPerformanceBehaviour()
            .AddBuildingBlockMediator(typeof(ServiceCollectionExtensions).Assembly);
            // .AddBuildingBlockValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        
        return services;
    }
}
