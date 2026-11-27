using EDW_TP5.Data;
using EDW_TP5.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EDW_TP5.Pages.Eventos;

public class IndexModel(EdwDbContext context) : PageModel
{
    public IList<Evento> Eventos { get; set; } = [];

    public async Task OnGetAsync()
    {
        Eventos = await context.Eventos
            .AsNoTracking()
            .OrderBy(evento => evento.DataHoraInicio)
            .ToListAsync();
    }
}