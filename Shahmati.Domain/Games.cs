namespace Shahmati.Domain;

public class Games
{
    public Guid GamesId { get; set; }


    public ICollection<PlayrsThisGame> Players
    {
        set
        {
            if (value.Count <= 2)
            {
                _players = value;
            }
            else
            {
                throw new InvalidOperationException("Игроков в шахматы должно быть не более 2");
            }
        }
        get
        {
            return _players;
        }
    }
    private ICollection<PlayrsThisGame> _players { get; set; } = new List<PlayrsThisGame>(2);
    
    
    public ICollection<Coordinates>? CoordinatesCollection {get; set; }
    
}

public class PlayrsThisGame
{
    public Guid Id { get; set; }
    
    public Games ThisGame { get; set; }
    public Guid ThisGameId { get; set; }
    
    public Player PlayerEntity { get; set; }
    public Guid PlayerEntityId { get; set; }
    
    public ColorPlayers Color { get; set; }
}

public enum ColorPlayers
{
    white = 0,
    black = 1 
}

