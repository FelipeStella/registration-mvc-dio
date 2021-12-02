using System.ComponentModel.DataAnnotations;

namespace WebApplicationMVC.Models
{
  public class RegisterUserViewModelInput
  {
    [Required(ErrorMessage = "O nome de usuário é obrigatório!")]
    public string UserName { get; set; }

    [Required(ErrorMessage = "O e-mail é obrigatório!")]
    [EmailAddress(ErrorMessage = "Informe um e-mail válido!")]
    public string Email { get; set; }

    [Required(ErrorMessage = "A senha é obrigatória!")]
    public string Password { get; set; }
  }
}


