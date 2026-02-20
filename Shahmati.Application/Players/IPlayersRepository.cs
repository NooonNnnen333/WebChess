using Shahmati.Domain;

namespace Shahmati.Infrastructure.Postgres;

public interface IPlayersRepository
{
    Task<Guid> AddAsync(Player player, CancellationToken cancellationToken);
    Task<IReadOnlyList<string>> GetAllNames(CancellationToken cancellationToken);
    Task<Player> GetOfId(Guid id, CancellationToken cancellationToken);
}