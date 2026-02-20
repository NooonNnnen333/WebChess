using Microsoft.EntityFrameworkCore;
using Shahmati.Domain;

namespace Shahmati.Infrastructure.Postgres;

public class CoordinatesReposotory : ICoordinatesReposotory
{
    private readonly ShahmatiDbContext _context;

    public CoordinatesReposotory(ShahmatiDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Добавить новый ход
    /// </summary>
    /// <param name="coordinates"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Guid> AddAsync(Coordinates coordinates, CancellationToken cancellationToken)
    {
        await _context.AddAsync(coordinates, cancellationToken);
        
        return coordinates.Id;
    }

    /// <summary>
    ///  Получить ходы из игры по её координатам
    /// </summary>
    /// <param name="gameId"/>
    /// <param name="cancellationToken"/>
    /// <returns></returns>
    public async Task<IReadOnlyList<Coordinates>> GetToIdOfGame(Guid gameId, CancellationToken cancellationToken)
    {
        return await _context.Coordinates
            .Where(x => x.GameId == gameId)
            .ToListAsync(cancellationToken);

    }
    
}