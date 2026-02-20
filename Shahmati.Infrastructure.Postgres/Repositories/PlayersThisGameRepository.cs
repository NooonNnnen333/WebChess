using Shahmati.Domain;

namespace Shahmati.Infrastructure.Postgres;

public class PlayersThisGameRepository
{
    private readonly ShahmatiDbContext _dbContext;

    public PlayersThisGameRepository(ShahmatiDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Guid> AddAsync(PlayrsThisGame entity, CancellationToken cancellationToken)
    {
        await _dbContext.PlayrsThisGame.AddAsync(entity, cancellationToken);

        return entity.Id;
    }
}