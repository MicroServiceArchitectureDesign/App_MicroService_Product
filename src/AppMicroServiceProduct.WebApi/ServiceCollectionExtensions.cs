using AppMicroServiceBuildingBlock.Contract.WebApiContracts.ConsulSetup;
using AppMicroServiceBuildingBlock.Shared.Extensions.ApplicationBuilderExtensions;
using AppMicroServiceProduct.Application;
using AppMicroServiceProduct.Infrastructure;

namespace AppMicroServiceProduct.WebApi;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddWebApiServices(this WebApplicationBuilder builder)
    {
        var services = builder.Services;

        services.AddControllers();
        services.AddHealthChecks();

        services.AddBuildingBlockConsulService(p =>
        {
            p.ServiceDiscoveryAddress = new Uri("http://consul:8500");
            p.ServiceAddress = new Uri("https://localhost:5001");
            p.ServiceHealthCheckEndpoint = new Uri("https://localhost:5001/hc");
            p.ServiceName = "Products";
            p.ServiceId = "Products_{01}";
        });

        services
            .AddApplicationServices()
            .AddInfrastructureServices();

        services.AddSwaggerBuildingBlock();
        return services;
    }
}