using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shahmati.Domain;

namespace Shahmati.Infrastructure.Postgres;

public class GameConfiguration : IEntityTypeConfiguration<Games>
{
    public void Configure(EntityTypeBuilder<Games> configurationOfGames)
    {
        configurationOfGames.HasKey(c => c.GamesId);
        configurationOfGames.ComplexProperty(x => x.Hodie, b =>
        {
            b.Property(p => p.bukva).HasColumnName("hodie_bukva");
            b.Property(p => p.integer).HasColumnName("hodie_integer");
        });


    }
}