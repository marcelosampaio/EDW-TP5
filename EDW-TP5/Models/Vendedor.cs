namespace EDW_TP5.Models;

public class Vendedor : Funcionario
{
    public int PontoDeVendaId { get; set; }
    public PontoDeVenda PontoDeVenda { get; set; } = null!;
}