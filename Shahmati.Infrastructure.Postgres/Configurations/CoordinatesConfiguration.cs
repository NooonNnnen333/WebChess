using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shahmati.Domain;

namespace Shahmati.Infrastructure.Postgres;

public static class CoordinatesConfiguration 
{
    public static void ConfigureCoordinates(this OwnedNavigationBuilder<Games, Coordinates> configureOfCoordinates)
    {
        
        /* Ключ */
        configureOfCoordinates.HasKey(x => x.Id);
//-----------------------------------------------------------------------------------
        
        /* Буквенное значение координаты на доске */
        configureOfCoordinates.Property(x => x.Bukva)
            .IsRequired();
//-----------------------------------------------------------------------------------
        
        /* Численное значение координаты на доске */
        configureOfCoordinates.Property(x => x.Integer)
            .IsRequired();
//-----------------------------------------------------------------------------------
    }
}