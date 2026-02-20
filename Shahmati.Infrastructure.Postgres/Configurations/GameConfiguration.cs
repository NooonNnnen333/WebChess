using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shahmati.Domain;

namespace Shahmati.Infrastructure.Postgres;

public class GameConfiguration : IEntityTypeConfiguration<Games>
{
    public void Configure(EntityTypeBuilder<Games> configurationOfGames)
    {
        /* Ключи */
        configurationOfGames.HasKey(c => c.GamesId);
//-----------------------------------------------------------------------------------

        /* Ходы */
        configurationOfGames.HasMany(x => x.CoordinatesCollection)
            .WithOne(x => x.Game)
            .HasForeignKey(x => x.GameId);
//-----------------------------------------------------------------------------------

        /* Игроки в игре */
        configurationOfGames.HasMany(x => x.Players)
            .WithOne(x => x.ThisGame)
            .HasForeignKey(x => x.ThisGameId);
//-----------------------------------------------------------------------------------
    }
}