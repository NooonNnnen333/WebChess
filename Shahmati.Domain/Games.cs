namespace Shahmati.Domain;

public class Games
{
    // public Task(Guid _gamesId, 
    //     Coordinates[] _hodie/*, 
    //     Players _playersThisGame*/)
    // {
    //     GamesId = _gamesId;
    //     Hodie = _hodie;
    //     // PlayersThisGame = _playersThisGame;
    // }
    
    public Guid GamesId { get; set; }
    public Coordinates Hodie { get; set; }
    // public Players PlayersThisGame { get; set; }

}

public struct Coordinates
{
    public char bukva;
    public short integer;
}

