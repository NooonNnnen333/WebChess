namespace Shahmati.Domain;

public class Player
{
    // public Player(Guid _PlayersId,
    //         string _Name,
    //         string _SurName,
    //         string _Patronymic,
    //         int _Reyting)
    // {
    //     Guid PlayersId = _PlayersId;
    //     string Name = _Name;
    //     string SurName = _SurName;
    //     string Patronymic = _Patronymic;
    //     int Reyting = _Reyting;
    // }
    
    public Guid PlayersId { get; set; }
    public string Name { get; set; }
    public string SurName { get; set; } // Фамилия
    public string Patronymic { get; set; } // Отчество
    public int Reyting { get; set; }
    
    // Потом добавлю
    public ICollection<PlayrsThisGame>? Games { get; set; }
    
}