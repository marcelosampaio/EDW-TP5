
using EDW_TP5.Models;
using Microsoft.EntityFrameworkCore;

namespace EDW_TP5.Data;

public class EdwDbContext(DbContextOptions<EdwDbContext> options)
    : DbContext(options)
{
    public DbSet<Evento> Eventos => Set<Evento>();
    public DbSet<Produto> Produtos => Set<Produto>();
    public DbSet<PontoDeVenda> PontosDeVenda => Set<PontoDeVenda>();

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

        modelBuilder.Entity<PontoDeVenda>()
            .HasOne(ponto => ponto.Evento)
            .WithMany()
            .HasForeignKey(ponto => ponto.EventoId);

        modelBuilder.Entity<PontoDeVenda>()
            .HasMany(ponto => ponto.Produtos)
            .WithMany(produto => produto.PontosDeVenda)
            .UsingEntity(
                "PontoDeVendaProduto",
                right => right.HasOne(typeof(Produto))
                    .WithMany()
                    .HasForeignKey("ProdutoId")
                    .HasPrincipalKey(nameof(Produto.ProdutoId)),
                left => left.HasOne(typeof(PontoDeVenda))
                    .WithMany()
                    .HasForeignKey("PontoDeVendaId")
                    .HasPrincipalKey(nameof(PontoDeVenda.PontoDeVendaId)),
                join =>
                {
                    join.HasKey("PontoDeVendaId", "ProdutoId");
                }
            );

        modelBuilder.Entity<PontoDeVenda>().HasData(
            new PontoDeVenda
            {
                PontoDeVendaId = 1,
                Nome = "Barraca do Cachorro Quente",
                EventoId = 1
            },
            new PontoDeVenda
            {
                PontoDeVendaId = 2,
                Nome = "Barraca de Bebidas",
                EventoId = 1
            }
        );

        modelBuilder.Entity<Produto>().HasData(
            new Produto
            {
                ProdutoId = 1,
                Nome = "Cachorro-quente",
                Preco = 10.00m
            },
            new Produto
            {
                ProdutoId = 2,
                Nome = "Refrigerante",
                Preco = 8.00m
            },
            new Produto
            {
                ProdutoId = 3,
                Nome = "Água",
                Preco = 6.00m
            },
            new Produto
            {
                ProdutoId = 4,
                Nome = "Cerveja",
                Preco = 8.00m
            }
        );

        modelBuilder.Entity("PontoDeVendaProduto").HasData(
            new { PontoDeVendaId = 1, ProdutoId = 1 },
            new { PontoDeVendaId = 2, ProdutoId = 2 },
            new { PontoDeVendaId = 2, ProdutoId = 3 },
            new { PontoDeVendaId = 2, ProdutoId = 4 }
        );

        base.OnModelCreating(modelBuilder);
    }
}
