using Refit;
using System.Collections.Generic;
using WebApplicationMVC.Models;

namespace WebApplicationMVC.Services
{
  public interface ICourseService
  {
    [Post("/api/v1/courses/register")]
    [Headers("Authorization: Bearer")]
    Task<RegisterCourseViewModelOutput> Register(RegisterCourseViewModelInput input);

    [Get("/api/v1/courses/list")]
    [Headers("Authorization: Bearer")]
    Task<IList<ListCoursesViewModelOutput>> List();
  }
}
