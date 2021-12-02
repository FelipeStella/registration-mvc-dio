using Microsoft.AspNetCore.Mvc;
using Refit;
using WebApplicationMVC.Models;
using WebApplicationMVC.Services;

namespace WebApplicationMVC.Controllers
{
  [Microsoft.AspNetCore.Authorization.Authorize]
  public class CourseController : Controller
  {
    private readonly ICourseService _courseService;

    public CourseController(ICourseService courseService)
    {
      _courseService = courseService;
    }
    
    public IActionResult Register()
    {
      return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterCourseViewModelInput registerCourseViewModelInput)
    {
      try
      {
        var course = await _courseService.Register(registerCourseViewModelInput);
        ModelState.AddModelError("", $"O Curso {course.Name} foi cadastrado com sucesso!");
      }
      catch (ApiException error)
      {
        ModelState.AddModelError("", error.Message);
      }
      catch (Exception error)
      {
        ModelState.AddModelError("", error.Message);
      }

      return View();
    }

    public async Task<IActionResult> List()
    {

      try
      {
        var courses = await _courseService.List();
        return View(courses);
      }
      catch (ApiException error)
      {
        ModelState.AddModelError("", error.Message);
      }
      catch (Exception error)
      {
        ModelState.AddModelError("", error.Message);
      }


      //var listCourses = new List<ListCoursesViewModelOutput>();

      //listCourses.Add(new ListCoursesViewModelOutput
      //{
      //  Name = "Javascript",
      //  Description = "Curso de javascript",
      //  Login = "felipe.stella"
      //});

      //listCourses.Add(new ListCoursesViewModelOutput
      //{
      //  Name = "CSharp",
      //  Description = "Curso de C#",
      //  Login = "felipe.stella"
      //});

      return View();
    }
  }
}
