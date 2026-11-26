namespace EDW_TP5.Models;

public class Evento
{
    public int EventoId { get; set; }
    public string Nome { get; set; } = string.Empty;
    public DateTime DataHoraInicio { get; set; }
    public DateTime DataHoraFim { get; set; }
}