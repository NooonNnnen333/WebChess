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

    /// <summary>
    /// Добавить новую игру
    /// </summary>
    /// <param name="games">игра</param>
    /// <param name="cancellationToken"/>
    /// <returns></returns>
    public async Task<Guid> AddAsync(Games games, CancellationToken cancellationToken)
    {
        await _context.Games.AddAsync(games, cancellationToken);
    
        await _context.SaveChangesAsync(cancellationToken);
        
        return games.GamesId;
    }

    /// <summary>
    /// Добавит ход в игре по её id
    /// </summary>
    /// <param name="coordinates"/>
    /// <param name="cancellationToken"/>
    /// <returns></returns>
    public async Task<Guid> AddMoveAsync(Coordinates coordinates, CancellationToken cancellationToken)
    {
        Games rGame = await _context.Games
            .SingleAsync(x => x.GamesId == coordinates.GameId, cancellationToken);
        
        rGame.CoordinatesCollection?.Add(coordinates);

        await _context.SaveChangesAsync(cancellationToken);
        
        return coordinates.Id;
    }

    public async Task<Guid> SaveAsync(Games games, CancellationToken cancellationToken) => throw new NotImplementedException();

    public async Task<Guid> DeleteAsync(Guid GameId, CancellationToken cancellationToken) => throw new NotImplementedException();

    /// <summary>
    /// Показать все игры
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<IReadOnlyList<Games>> GetAll(CancellationToken cancellationToken)
    {
        var gamesClases = await _context.Games.AsNoTracking()
            .ToListAsync(cancellationToken);
        
        return gamesClases;
    }

    public async Task<Games> GetByIdAsync(Guid GameId, CancellationToken cancellationToken) => throw new NotImplementedException();
    
    
}