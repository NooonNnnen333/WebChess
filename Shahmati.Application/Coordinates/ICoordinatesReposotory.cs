using Shahmati.Domain;

namespace Shahmati.Infrastructure.Postgres;

public interface ICoordinatesReposotory
{
    Task<Guid> AddAsync(Coordinates coordinates, CancellationToken cancellationToken);
    Task<IReadOnlyList<Coordinates>> GetToIdOfGame(Guid gameId, CancellationToken cancellationToken);
}