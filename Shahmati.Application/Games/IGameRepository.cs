using Shahmati.Contracts;
using Shahmati.Domain;

namespace Shahmati.Infrastructure.Postgres;

public interface IGameRepository
{
    Task<Guid> AddAsync(Games games, CancellationToken cancellationToken);
    Task<Guid> SaveAsync(Games games, CancellationToken cancellationToken);
    Task<Guid> DeleteAsync(Guid GameId, CancellationToken cancellationToken);
    Task<IReadOnlyList<Games>> GetAll(CancellationToken cancellationToken);
    Task<Games> GetByIdAsync(Guid GameId, CancellationToken cancellationToken);
}