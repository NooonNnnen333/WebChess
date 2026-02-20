using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shahmati.Domain;

namespace Shahmati.Infrastructure.Postgres;

public class PlayrsThisGameCoonfigurations : IEntityTypeConfiguration<Domain.PlayrsThisGame>
{
    public void Configure(EntityTypeBuilder<PlayrsThisGame> configurationOfPlayrsThisGame)
    {
        configurationOfPlayrsThisGame.HasKey(x => x.Id);

        configurationOfPlayrsThisGame.HasOne(x => x.PlayerEntity)
            .WithMany(x => x.Games)
            .HasForeignKey(x => x.PlayerEntityId);

        configurationOfPlayrsThisGame.Property(x => x.Color);
    }
}