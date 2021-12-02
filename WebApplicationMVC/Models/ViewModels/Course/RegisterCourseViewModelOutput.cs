using System.ComponentModel.DataAnnotations;

namespace WebApplicationMVC.Models
{
  public class RegisterCourseViewModelOutput
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public string Login { get; set; }
  }
}
