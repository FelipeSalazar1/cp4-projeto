namespace ConsultoriaDev.Models;

public class Problema
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public string TempoResposta { get; set; } = string.Empty;
    public decimal Preco { get; set; }
}
