using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Refit;
using System.Net.Security;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebApplicationMVC.Models;
using WebApplicationMVC.Services;

namespace WebApplicationMVC.Controllers
{
  public class UserController : Controller
  {
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
      _userService = userService;
    }
    
    public IActionResult Register()
    {
      return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterUserViewModelInput registerUserViewModelInput)
    {
      try
      {
        var user = await _userService.Register(registerUserViewModelInput);

        ModelState.AddModelError("", $"Usuário {user.UserName} foi cadastrado com sucesso!");
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

    public IActionResult Login()
    {
      return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModelInput loginViewModelInput)
    {
      try
      {
        var user = await _userService.Login(loginViewModelInput);

        var claims = new List<Claim>
        {
          new Claim(ClaimTypes.NameIdentifier, user.User.Code.ToString()),
          new Claim(ClaimTypes.Name, user.User.UserName),
          new Claim(ClaimTypes.Email, user.User.UserEmail),
          new Claim("token", user.Token),
        };

        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

        var authProperties = new AuthenticationProperties
        {
          ExpiresUtc = new DateTimeOffset(DateTime.UtcNow.AddDays(1)),
        };

        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

        return RedirectToAction("Index", "Home");
      }
      catch (ApiException error)
      {
        ModelState.AddModelError("", error.Content);
      }
      catch (Exception error)
      {
        ModelState.AddModelError("", error.Message);
      }
      return View();
    }

    public IActionResult Exit()
    {
      return View();
    }

    [HttpPost]
    public async Task<IActionResult> Logoff()
    {
      await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

      return RedirectToAction($"{nameof(Login)}");
    }
  }
}
