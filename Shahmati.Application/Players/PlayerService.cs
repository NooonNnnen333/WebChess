using FluentValidation;
using Microsoft.Extensions.Logging;
using Shahmati.Contracts;
using Shahmati.Infrastructure.Postgres;

namespace Shahmati.Application;

public class PlayerService : IPlayerService
{
    private readonly IPlayersRepository _repository;
    private readonly IValidator<PlayerDto> _validator;
    private readonly ILogger<PlayerService> _logger;

    public PlayerService(IPlayersRepository repository,
        IValidator<PlayerDto> validator,
        ILogger<PlayerService> logger)
    {
        _repository  = repository;
        _validator = validator;
        _logger = logger;
    }

    public async Task<Guid> CreateAsync(PlayerDto playerReqest, CancellationToken cancellationToken)
    {
        var validationFlaf = await _validator.ValidateAsync(playerReqest, cancellationToken);
        if (!validationFlaf.IsValid)
        {
            throw new ValidationException(validationFlaf.Errors);
        }

        var _playerId = Guid.NewGuid();
        var PlayerEntity = new Domain.Player()
        {
            PlayersId = _playerId,
            Name = playerReqest.Name,
            Patronymic = playerReqest.Patronymic,
            Reyting = playerReqest.Reyting,
            SurName = playerReqest.SurName
        };
        var id = _repository.AddAsync(PlayerEntity, cancellationToken);
        
        _logger.LogInformation($"Был создан новый игрок с индексом {_playerId}");
        return _playerId;
    }
}