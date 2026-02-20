using Microsoft.EntityFrameworkCore;
using Shahmati.Domain;

namespace Shahmati.Infrastructure.Postgres;

public class ShahmatiDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public ShahmatiDbContext(DbContextOptions<ShahmatiDbContext> options) : base(options)
    {
    }
    
    public DbSet<Games> Games { get; set; }
    public DbSet<Coordinates> Coordinates { get; set; }
    public DbSet<Player> Player { get; set; }
    
    public DbSet<PlayrsThisGame> PlayrsThisGame { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ShahmatiDbContext).Assembly);
    }
    
    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     if (!optionsBuilder.IsConfigured)
    //     {
    //         optionsBuilder.UseNpgsql("Database");
    //     }
    // }
}