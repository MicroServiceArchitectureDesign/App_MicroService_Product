using AppMicroServiceBuildingBlock.Shared.Extensions.ApplicationBuilderExtensions;
using AppMicroServiceBuildingBlock.Shared.Extensions.ServiceCollectionExtensions;
using AppMicroServiceProduct.Application;
using AppMicroServiceProduct.Infrastructure;
using AppMicroServiceProduct.WebApi;
using AppMicroServiceBuildingBlock.Contract.WebApiContracts.ConsulSetup;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddHealthChecks();
// builder.Services.AddConsuleService();

builder.Services.AddBuildingBlockConsulService(p =>
    {
        p.ServiceDiscoveryAddress = new Uri("http://localhost:8500");
        p.ServiceAddress = new Uri("https://localhost:6001");
        p.ServiceHealthCheckEndpoint = new Uri("https://localhost:6001/hc");
        p.ServiceName = "Products";
        p.ServiceId = "Products_{01}";
    });

builder.Services
    .AddApplicationServices()
    .AddInfrastructureServices()
    .AddWebApiServices();


builder.Services.AddSwaggerBuildingBlock();

var app = builder.Build();

app.UseSwaggerBuildingBlock(Environments.Development);

app.MapHealthChecks("/hc");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();