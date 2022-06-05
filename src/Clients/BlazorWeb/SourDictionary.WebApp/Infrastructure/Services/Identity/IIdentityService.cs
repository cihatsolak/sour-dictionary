namespace SourDictionary.WebApp.Infrastructure.Services.Identity
{
    public interface IIdentityService
    {
        bool IsLoggedIn { get; }

        Guid GetUserId();
        string GetUserName();
        string GetUserToken();
        ValueTask<bool> LoginAsync(LoginUserCommand command);
        void Logout();
    }
}