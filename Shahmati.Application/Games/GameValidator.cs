using System.Data;
using FluentValidation;
using FluentValidation.Validators;
using Shahmati.Contracts;
using Shahmati.Contracts;

namespace Shahmati.Application.Games;

public class CreateGameValidator : AbstractValidator<CreateGameDto>
{
    public CreateGameValidator()
    {
        RuleFor(x => x.GamesId).NotEmpty();
        RuleFor(x => x.bukva).NotEmpty();
        RuleFor(x => x.integer).NotEmpty();
    }
}