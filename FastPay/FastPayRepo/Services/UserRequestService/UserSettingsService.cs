
namespace FastPayRepo.UserRequestService;

internal class UserSettingsService : IUserSettingsService
{
    private readonly HttpContext httpContext;

    public UserSettingsService(IHttpContextAccessor httpContextAccessor)
    {
        httpContext = httpContextAccessor.HttpContext;
    }

    public string GetLang()
    {
        string userLanguage = httpContext.Request.Headers["Accept-Language"];
        return userLanguage;
    }

    public string GetToken()
    {
        string userToken = httpContext.Request.Headers["Authorization"];
        return userToken;
    }
}

