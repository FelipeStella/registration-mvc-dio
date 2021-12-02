using System.ComponentModel.DataAnnotations;

namespace WebApplicationMVC.Models
{
  public class RegisterCourseViewModelInput
  {
    [Required(ErrorMessage = "O nome do curso é obrigatório!")]
    public string Name { get; set; }

    [Required(ErrorMessage = "A descrição do curso é obrigatória!")]
    public string Description { get; set; }
  }
}
