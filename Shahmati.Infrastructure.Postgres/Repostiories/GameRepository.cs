using Microsoft.EntityFrameworkCore;
using Shahmati.Contracts;
using Shahmati.Domain;

namespace Shahmati.Infrastructure.Postgres;

public class GameRepository : IGameRepository
{
    private readonly ShahmatiDbContext _context;
    
    public GameRepository(ShahmatiDbContext shahmatiDbContext)
    {
        _context = shahmatiDbContext;
    }

    public async Task<Guid> AddAsync(Games games, CancellationToken cancellationToken)
    {
        await _context.Games.AddAsync(games, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);
        
        return games.GamesId;
    }

    public async Task<Guid> SaveAsync(Games games, CancellationToken cancellationToken) => throw new NotImplementedException();

    public async Task<Guid> DeleteAsync(Guid GameId, CancellationToken cancellationToken) => throw new NotImplementedException();

    public async Task<IReadOnlyList<CreateGameDto>> GetAll(CancellationToken cancellationToken)
    {
        var gamesClases = await _context.Games.AsNoTracking().ToListAsync(cancellationToken);


        IReadOnlyList<CreateGameDto> dtoGames = gamesClases
            .Select(gameClass
                => new CreateGameDto(gameClass.GamesId,
                    gameClass.Hodie.bukva,
                    gameClass.Hodie.integer)
                )
            .ToList();
        
        return dtoGames;
    }

    public async Task<Games> GetByIdAsync(Guid GameId, CancellationToken cancellationToken) => throw new NotImplementedException();
    
}