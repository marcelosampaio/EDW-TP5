namespace EDW_TP5.Models;

public class CarteiraDigital
{
    public int CarteiraDigitalId { get; set; }
    public string QrCode { get; set; } = string.Empty;
    public decimal Saldo { get; set; }

    public int EventoId { get; set; }
    public Evento Evento { get; set; } = null!;
}