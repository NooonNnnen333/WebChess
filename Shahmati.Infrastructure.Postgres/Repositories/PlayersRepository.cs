using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Shahmati.Domain;

namespace Shahmati.Infrastructure.Postgres;

public class PlayersRepository : IPlayersRepository
{
    private readonly ShahmatiDbContext _context;

    public PlayersRepository(ShahmatiDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> AddAsync(Player player, CancellationToken cancellationToken)
    {
        await _context.Player.AddAsync(player, cancellationToken);
        
        return player.PlayersId;
    }

    public async Task<IReadOnlyList<string>> GetAllNames(CancellationToken cancellationToken)
    {
        IReadOnlyList<string> names = _context.Player
            .AsNoTracking()
            .Select(x => x.Name)
            .ToList();

        return names;
    }

    public async Task<Player> GetOfId(Guid id, CancellationToken cancellationToken)
    {
        var retPlaer = await _context.Player
            .FirstOrDefaultAsync(x => x.PlayersId == id, cancellationToken);

        return retPlaer ?? throw new ValidationException();
    }
    
    
}