using System.ComponentModel.DataAnnotations;

namespace ConsultoriaDev.Models;

public class Solicitacao
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Informe o nome.")]
    public string NomeCliente { get; set; } = string.Empty;

    [Required(ErrorMessage = "Informe o e-mail.")]
    [EmailAddress(ErrorMessage = "Digite um e-mail válido.")]
    public string EmailCliente { get; set; } = string.Empty;

    public int ProblemaId { get; set; }
    public string ProblemaNome { get; set; } = string.Empty;
    public string Status { get; set; } = "Pendente";
    public DateTime DataSolicitacao { get; set; } = DateTime.Now;
    public string? DevResponsavel { get; set; }
    public string? WhatsAppDev { get; set; }
}
