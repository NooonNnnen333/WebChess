using Shahmati.Contracts;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Shahmati.Domain;
using Shahmati.Infrastructure.Postgres;

namespace Shahmati.Application.Games;

public class GameService : IGameService
{
    private readonly IGameRepository _repository;
    private readonly IValidator<CreateGameDto> _createValidator;
    private readonly ILogger<GameService> _logger;

    public GameService(IValidator<CreateGameDto> CreateValidator, IGameRepository Repository, ILogger<GameService> logger)
    {
        _createValidator = CreateValidator;
        _repository = Repository;
        _logger = logger;
    }

    public async Task<Guid> Create(CreateGameDto Dto, CancellationToken сancellationToken)
    {
        await _createValidator.ValidateAndThrowAsync(Dto, сancellationToken);

        var gameId = Guid.NewGuid();
        var game = new Domain.Games
        {
            GamesId = gameId,
            Hodie = new Coordinates()
            {
                bukva = Dto.bukva,
                integer = Dto.integer
            }
        };

        await _repository.AddAsync(game, сancellationToken);
        _logger.LogInformation("Зарегестрирована новая игра.");
        
        return Dto.GamesId;
    }

    public async Task<IReadOnlyList<CreateGameDto>> GetAll(CancellationToken cancellationToken)
    {
        return await _repository.GetAll(cancellationToken);
    }
}