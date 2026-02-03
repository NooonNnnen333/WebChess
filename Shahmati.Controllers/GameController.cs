using Microsoft.AspNetCore.Mvc;
using Shahmati.Application.Games;
using Shahmati.Contracts;

namespace Shahmati.Controllers;

[ApiController]
[Route("[controller]")]
public class GameController : ControllerBase
{
    private readonly IGameService _iService;

    public GameController(IGameService iService)
    {
        _iService = iService;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateGameDto createGameDto, CancellationToken cancellationToken)
    {
        await _iService.Create(createGameDto, cancellationToken);

        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var allGames = await _iService.GetAll(cancellationToken);
        return Ok(allGames);
    }
}