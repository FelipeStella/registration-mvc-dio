using Refit;
using WebApplicationApi.Models.Views.Users;
using WebApplicationMVC.Models;

namespace WebApplicationMVC.Services
{
  public interface IUserService
  {
    [Post("/api/v1/user/register")]
    Task<RegisterUserViewModelInput> Register(RegisterUserViewModelInput input);

    [Post("/api/v1/user/login")]
    Task<LoginViewModelOutput> Login(LoginViewModelInput input);
  }
}
