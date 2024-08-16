using AppMicroServiceBuildingBlock.Contract.WebApiContracts.ConsulSetup;
using AppMicroServiceBuildingBlock.Shared.Extensions.ApplicationBuilderExtensions;
using AppMicroServiceBuildingBlock.Shared.Extensions.ServiceCollectionExtensions;
using AppMicroServiceProduct.Application;
using AppMicroServiceProduct.Infrastructure;
using AppMicroServiceProduct.WebApi;
using AppMicroServiceProduct.WebApi.ServiceDiscoverySetup;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddHealthChecks();
builder.Services.AddConsuleService();
// builder.Services.AddBuildingBlockConsulService(p =>
//     {
//         p.ServiceDiscoveryAddress = new Uri("http://localhost:8500");
//         p.ServiceAddress = new Uri("https://localhost:7293");
//         p.ServiceHealthCheckEndpoint = new Uri("https://localhost:7293/hc");
//         p.ServiceName = "Products";
//         p.ServiceId = "Products_{01}";
//     });

builder.Services
    .AddApplicationServices()
    .AddInfrastructureServices()
    .AddWebApiServices();


 builder.Services.AddSwaggerBuildingBlock();
// builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwaggerBuildingBlock(Environments.Development);
// app.UseSwagger();
// app.UseSwaggerUI(c =>
// {
//     c.SwaggerEndpoint("/swagger/v1/swagger.json", "Product service v1");
// });
app.MapHealthChecks("/hc");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();