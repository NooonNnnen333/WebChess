using Shahmati.Contracts;

namespace Shahmati.Application.Games;

public interface IGameService
{
    Task<Guid> Create(CreateGameDto Dto, CancellationToken сancellationToken);
    
    Task<IReadOnlyList<CreateGameDto>> GetAll(CancellationToken cancellationToken);
}