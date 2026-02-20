namespace Shahmati.Domain;

public class Coordinates
{
    public Guid Id { get; set; }
    public char Bukva { get; set; }
    public short Integer { get; set; }
    
    public Guid GameId { get; set; }
    public Games Game { get; set; }
    
}