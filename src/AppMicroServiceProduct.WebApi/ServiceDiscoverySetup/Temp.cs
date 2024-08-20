using Consul;

namespace AppMicroServiceProduct.WebApi.ServiceDiscoverySetup;

public class ServiceDiscoveryHostedService(IConsulClient consulClient, ILogger<ServiceDiscoveryHostedService> logger)
    : IHostedLifecycleService
{
    public Task StartingAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("StartingAsync");
        return Task.CompletedTask;
    }
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        var registerModel = new AgentServiceRegistration()
        {
            Name = ServiceDiscoveryConfig.ServiceName,
            ID = ServiceDiscoveryConfig.ServiceId,
            Address = ServiceDiscoveryConfig.ServiceAddress.Host,
            Port = ServiceDiscoveryConfig.ServiceAddress.Port,
        };
        await consulClient.Agent.ServiceRegister(registerModel, cancellationToken);
    }

    public Task StartedAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("StartedAsync");
        return Task.CompletedTask;
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        await consulClient.Agent.ServiceDeregister(ServiceDiscoveryConfig.ServiceId, cancellationToken);
    }

    public Task StoppedAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("StoppedAsync");
        return Task.CompletedTask;
    }

    public Task StoppingAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("StoppingAsync");
        return Task.CompletedTask;
    }
}

public static class ConsulRegistrationExtensions
{
    public static IServiceCollection AddConsuleService(this IServiceCollection services)
    {
        services.Configure<HostOptions>(p =>
        {
            p.ServicesStartConcurrently = true;
            p.ServicesStopConcurrently = false;
        });
        
        services.AddHostedService<ServiceDiscoveryHostedService>();
        services.AddSingleton<IConsulClient, ConsulClient>(p => new ConsulClient(q =>
        {
            q.Address = ServiceDiscoveryConfig.ServiceDiscoveryAddress;
        }));
        return services;
    }
}

public static class ServiceDiscoveryConfig
{
    public static Uri ServiceDiscoveryAddress = new("http://localhost:8500");
    public static Uri ServiceAddress = new("https://localhost:6001");
    public static Uri ServiceHealthCheckEndpoint = new("https://localhost:6001/hc");
    public static string ServiceName = "Products";
    public static string ServiceId = $"{ServiceName}_{01}";
}