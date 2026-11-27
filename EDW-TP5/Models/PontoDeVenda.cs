namespace EDW_TP5.Models;

public class PontoDeVenda
{
    public int PontoDeVendaId { get; set; }
    public string Nome { get; set; } = string.Empty;

    public int EventoId { get; set; }
    public Evento Evento { get; set; } = null!;

    public ICollection<Produto> Produtos { get; set; } = [];
}