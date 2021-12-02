using System.ComponentModel.DataAnnotations;

namespace WebApplicationMVC.Models
{
  public class LoginViewModelInput
  {
    [Required(ErrorMessage = "O nome de usuário é obrigatório!")]
    public string LoginProvider { get; set; }

    [Required(ErrorMessage = "A senha é obrigatória!")]
    public string ProviderKey { get; set; }
  }
}
