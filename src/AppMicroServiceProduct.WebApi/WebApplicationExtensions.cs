using AppMicroServiceBuildingBlock.Shared.Extensions.ServiceCollectionExtensions;

namespace AppMicroServiceProduct.WebApi;

public static class WebApplicationExtensions
{
    public static void UseApplicationBuilder(this WebApplication app)
    {
        app.UseSwaggerBuildingBlock(Environments.Development);

        app.MapHealthChecks("/hc");
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}
