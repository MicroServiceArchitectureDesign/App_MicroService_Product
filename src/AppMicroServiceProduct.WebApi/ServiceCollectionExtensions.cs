using AppMicroServiceProduct.WebApi.ServiceDiscoverySetup;
using Consul;

namespace AppMicroServiceProduct.WebApi;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddWebApiServices(this IServiceCollection services)
    {
        //services.AddSingleton<IConsulClient, ConsulClient>(p => new ConsulClient(q =>
        //{
        //    q.Address = ServiceDiscoveryConfig.ServiceDiscoveryAddress;
        //}));
        return services;
    }

    public static IApplicationBuilder RegisterWithConsul(this WebApplication app)
    {
        IConsulClient consulClient = app.Services.GetRequiredService<IConsulClient>();
       
        var registerModel = new AgentServiceRegistration()
        {
            Name = ServiceDiscoveryConfig.ServiceName,
            ID = ServiceDiscoveryConfig.ServiceId,
            Address = ServiceDiscoveryConfig.ServiceAddress.Host,
            Port = ServiceDiscoveryConfig.ServiceAddress.Port,
        };
        consulClient.Agent.ServiceRegister(registerModel).Wait();



        app.Lifetime.ApplicationStopping.Register(() =>
        {
            consulClient.Agent.ServiceDeregister(ServiceDiscoveryConfig.ServiceId).Wait();
        });


        return app;
    }
}