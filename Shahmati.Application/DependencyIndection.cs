using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Shahmati.Application.Games;
using Shahmati.Infrastructure.Postgres;

namespace Shahmati.Application;

public static class DependencyIndection
{
    public static IServiceCollection AddAplication(this IServiceCollection service)
    {
        service.AddValidatorsFromAssembly(typeof(DependencyIndection).Assembly);

        service.AddScoped<IGameService, GameService>();
        service.AddScoped<IPlayerService, PlayerService>();
        
        return service;
    }
}