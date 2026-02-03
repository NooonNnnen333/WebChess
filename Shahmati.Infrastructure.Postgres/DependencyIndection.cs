using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Shahmati.Infrastructure.Postgres;

public static class DependencyIndection
{
    public static IServiceCollection AddPostgresInfrastraction(this IServiceCollection service, IConfiguration configuration)
    {
        service.AddDbContext<ShahmatiDbContext>(option => option.UseNpgsql(configuration.GetConnectionString("Database")));

        service.AddScoped<IGameRepository, GameRepository>();

        return service;
    }
}