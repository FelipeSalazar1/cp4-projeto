using System.ComponentModel.DataAnnotations;

namespace ConsultoriaDev.Models;

public class LoginViewModel
{
    [Required(ErrorMessage = "Informe o usuário.")]
    public string Usuario { get; set; } = string.Empty;

    [Required(ErrorMessage = "Informe a senha.")]
    public string Senha { get; set; } = string.Empty;
}