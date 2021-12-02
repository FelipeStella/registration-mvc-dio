using System.Net.Http.Headers;

namespace WebApplicationMVC.Handlers
{
  public class BearerTokenMessageHandler : DelegatingHandler
  {
    private readonly IHttpContextAccessor _httpContextAccessor;

    public BearerTokenMessageHandler(IHttpContextAccessor httpContextAccessor)
    {
      _httpContextAccessor = httpContextAccessor;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage requestMessage,  CancellationToken cancellationToken)
    {
      if(requestMessage.Headers.Authorization != null)
      {
        var token = _httpContextAccessor.HttpContext.User.FindFirst("token").Value;
        requestMessage.Headers.Authorization = new AuthenticationHeaderValue(requestMessage.Headers.Authorization.Scheme, token); 
      }

      return await base.SendAsync(requestMessage, cancellationToken);
    }
  }
}
