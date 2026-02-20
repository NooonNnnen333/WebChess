using System.Data;
using FluentValidation;
using Shahmati.Contracts;
using Shahmati.Domain;

namespace Shahmati.Application.Players;

public class CreatePlayerValidator : AbstractValidator<PlayerDto>
{
    public CreatePlayerValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty();
        
    }
}