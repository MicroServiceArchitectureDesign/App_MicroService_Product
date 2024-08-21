using AppMicroServiceProduct.WebApi;

var builder = WebApplication.CreateBuilder(args);
builder.AddWebApiServices();

var app = builder.Build();
app.UseApplicationBuilder();