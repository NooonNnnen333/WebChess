using Shahmati.Application;
using Shahmati.Infrastructure.Postgres;

namespace Shahmati.Web;

public static class DependencyIndection
{
    public static IServiceCollection AddProgrammCollection(this IServiceCollection service, IConfiguration configuration)
    {
        service.AddWebDependencies();
        
        service.AddAplication();

        service.AddPostgresInfrastraction(configuration);
        
        return service;
    }
    
    private static IServiceCollection AddWebDependencies(this IServiceCollection service)
    {
        service.AddControllers();
        service.AddOpenApi();

        return service;
    }
    
}