using Shahmati.Domain;

namespace Shahmati.Contracts;

public record CreateGameDto(Guid GamesId, char bukva, short integer, Guid PlayerOneId, Guid PlayerTwoId);
