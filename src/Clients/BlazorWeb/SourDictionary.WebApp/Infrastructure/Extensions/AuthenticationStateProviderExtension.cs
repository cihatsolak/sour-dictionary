namespace SourDictionary.WebApp.Infrastructure.Extensions
{
    public static class AuthenticationStateProviderExtension
    {
        public static async ValueTask<Guid> GetUserIdAsync(this AuthenticationStateProvider provider)
        {
            AuthenticationState authenticationState = await provider.GetAuthenticationStateAsync();
            string userId = authenticationState.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            return !string.IsNullOrEmpty(userId) ? new Guid(userId) : Guid.Empty;
        }
    }
}
