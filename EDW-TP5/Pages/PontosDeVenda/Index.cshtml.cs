using EDW_TP5.Data;
using EDW_TP5.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EDW_TP5.Pages.PontosDeVenda;

public class IndexModel(EdwDbContext context) : PageModel
{
    public IList<PontoDeVenda> PontosDeVenda { get; set; } = [];

    public async Task OnGetAsync()
    {
        PontosDeVenda = await context.PontosDeVenda
            .AsNoTracking()
            .Include(ponto => ponto.Evento)
            .Include(ponto => ponto.Produtos)
            .OrderBy(ponto => ponto.PontoDeVendaId)
            .ToListAsync();
    }
}