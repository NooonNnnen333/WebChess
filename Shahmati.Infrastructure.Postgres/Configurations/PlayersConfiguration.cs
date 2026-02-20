using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shahmati.Domain;

namespace Shahmati.Infrastructure.Postgres;

public class PlayersConfiguration : IEntityTypeConfiguration<Player>
{
    public void Configure(EntityTypeBuilder<Player> configureOfPlayer)
    {
        /* Ключ */
        configureOfPlayer.HasKey(x => x.PlayersId);
//---------------------------------------------------------------------------------
        
        /* Имя игрока */
        configureOfPlayer.Property(x => x.Name)
            .IsRequired();
//---------------------------------------------------------------------------------
        
        /* Фамилия */
        configureOfPlayer.Property(x => x.SurName)
            .IsRequired();
//---------------------------------------------------------------------------------
        
        /* Отчество */
        configureOfPlayer.Property(x => x.Patronymic)
            .IsRequired(false);
//---------------------------------------------------------------------------------        
        
        /* Рэйтинг */
        configureOfPlayer.Property(x => x.Reyting)
            .HasDefaultValue(0);
//---------------------------------------------------------------------------------       

        // configureOfPlayer.HasOne(x => x.GamesActive)
        //     .WithOne(x => x.PlayerOne);

    }
}