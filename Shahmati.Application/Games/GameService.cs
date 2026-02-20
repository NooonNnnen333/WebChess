using Shahmati.Contracts;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Shahmati.Domain;
using Shahmati.Infrastructure.Postgres;

namespace Shahmati.Application.Games;

public class GameService : IGameService
{
    private readonly IGameRepository _repository;
    private readonly IPlayersRepository _repositoryPlayers;
    private readonly IValidator<CreateGameDto> _createValidator;
    private readonly ILogger<GameService> _logger;

    public GameService(IValidator<CreateGameDto> CreateValidator, IGameRepository Repository, ILogger<GameService> logger, IPlayersRepository repositoryPlayers)
    {
        _createValidator = CreateValidator;
        _repository = Repository;
        _logger = logger;
        _repositoryPlayers = repositoryPlayers;
    }

    public async Task<Guid> Create(CreateGameDto Dto, CancellationToken сancellationToken)
    {
        await _createValidator.ValidateAndThrowAsync(Dto, сancellationToken);

        var gameId = Guid.NewGuid();
        
        var playerWhite = await _repositoryPlayers.GetOfId(Dto.PlayerOneId, сancellationToken);
        var playerBlack = await _repositoryPlayers.GetOfId(Dto.PlayerTwoId, сancellationToken);

        PlayrsThisGame ptgW = new PlayrsThisGame
        {
            Id = Guid.NewGuid(),
            PlayerEntity = playerWhite,
            Color = ColorPlayers.white
        };
        
        PlayrsThisGame ptgB = new PlayrsThisGame
        {
            Id = Guid.NewGuid(),
            PlayerEntity = playerBlack,
            Color = ColorPlayers.black
        };
        
        var game = new Domain.Games
        {
            GamesId = gameId,
            Players = new List<PlayrsThisGame>{ptgW, ptgB}
        };

        var result = await _repository.AddAsync(game, сancellationToken);
        _logger.LogInformation("Зарегестрирована новая игра.");
        
        return result;
    }

    public async Task<IReadOnlyList<Domain.Games>> GetAll(CancellationToken cancellationToken)
    {
        return await _repository.GetAll(cancellationToken);
    }
}