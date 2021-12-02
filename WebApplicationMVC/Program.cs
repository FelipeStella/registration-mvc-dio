using Microsoft.AspNetCore.Authentication.Cookies;
using Refit;
using WebApplicationMVC.Handlers;
using WebApplicationMVC.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();

//Desabilita a verificação do certificado digital do lado do cliente (Não utilizar em ambiente de produção)
//Inicio
var clientHandler = new HttpClientHandler
{
  ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
};
//Fim

var config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json").Build();

builder.Services.AddRefitClient<IUserService>()
    .ConfigureHttpClient(c =>
    {
      c.BaseAddress = new Uri(config.GetValue<string>("UrlWebApplicationApi"));
    }).ConfigurePrimaryHttpMessageHandler(c => clientHandler);

builder.Services.AddTransient<BearerTokenMessageHandler>();

builder.Services.AddRefitClient<ICourseService>()
    .AddHttpMessageHandler<BearerTokenMessageHandler>()
    .ConfigureHttpClient(c =>
    {
      c.BaseAddress = new Uri(config.GetValue<string>("UrlWebApplicationApi"));
    }).ConfigurePrimaryHttpMessageHandler(c => clientHandler);

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
  .AddCookie(options =>
  {
    options.LoginPath = "/User/Login";
    options.AccessDeniedPath = "/User/Login";
  });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
  app.UseExceptionHandler("/Home/Error");
  // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
  app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
