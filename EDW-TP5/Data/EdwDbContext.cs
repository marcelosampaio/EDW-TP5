using EDW_TP5.Models;
using Microsoft.EntityFrameworkCore;

namespace EDW_TP5.Data;

public class EdwDbContext(DbContextOptions<EdwDbContext> options)
    : DbContext(options)
{
    public DbSet<Evento> Eventos => Set<Evento>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Evento>().HasData(
            new Evento
            {
                EventoId = 1,
                Nome = "Dezembro Junino",
                DataHoraInicio = new DateTime(2026, 12, 20, 18, 0, 0),
                DataHoraFim = new DateTime(2026, 12, 20, 23, 59, 0)
            }
        );

        base.OnModelCreating(modelBuilder);
    }
}