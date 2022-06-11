namespace SourDictionary.WebApp.Infrastructure.Auth
{
    public class AuthStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorage;
        private readonly AuthenticationState anonymous;

        public AuthStateProvider(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
            anonymous = new(new ClaimsPrincipal(new ClaimsIdentity()));
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            string jwtToken = await _localStorage.GetTokenAsync();
            if (string.IsNullOrWhiteSpace(jwtToken))
                return anonymous;

            JwtSecurityTokenHandler tokenHandler = new();
            JwtSecurityToken securityToken = tokenHandler.ReadJwtToken(jwtToken);

            ClaimsPrincipal claimsPrincipal = new(new ClaimsIdentity(securityToken.Claims, "jwtAuthType"));

            return new AuthenticationState(claimsPrincipal);
        }

        public void NotifyUserLogin(string userName, Guid userId)
        {
            ClaimsPrincipal claimsPrincipal = new(new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, userName),
                new Claim(ClaimTypes.NameIdentifier, userId.ToString())
            }, "jwtAuthType"));

            var authenticationState = Task.FromResult(new AuthenticationState(claimsPrincipal));

            NotifyAuthenticationStateChanged(authenticationState);
        }

        public void NotifyUserLogout()
        {
            var authState = Task.FromResult(anonymous);

            NotifyAuthenticationStateChanged(authState);
        }
    }
}
