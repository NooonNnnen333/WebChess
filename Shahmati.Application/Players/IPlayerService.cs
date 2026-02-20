using Shahmati.Contracts;

namespace Shahmati.Application;

public interface IPlayerService
{
    Task<Guid> CreateAsync(PlayerDto playerReqest, CancellationToken cancellationToken);
}