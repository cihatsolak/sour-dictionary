namespace SourDictionary.WebApp.Infrastructure.Auth
{
    public class AuthTokenHandler : DelegatingHandler
    {
        private readonly ISyncLocalStorageService _syncLocalStorageService;

        public AuthTokenHandler(ISyncLocalStorageService syncLocalStorageService)
        {
            _syncLocalStorageService = syncLocalStorageService;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            string token = _syncLocalStorageService.GetToken();
            if (!string.IsNullOrEmpty(token) && (request.Headers.Authorization is null || string.IsNullOrEmpty(request.Headers.Authorization.Parameter)))
                request.Headers.Authorization = new("bearer", token);

            return base.SendAsync(request, cancellationToken);
        }
    }
}
