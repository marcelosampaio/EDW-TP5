namespace EDW_TP5.Models;

public class Produto
{
    public int ProdutoId { get; set; }
    public string Nome { get; set; } = string.Empty;
    public decimal Preco { get; set; }

    public ICollection<PontoDeVenda> PontosDeVenda { get; set; } = [];
}