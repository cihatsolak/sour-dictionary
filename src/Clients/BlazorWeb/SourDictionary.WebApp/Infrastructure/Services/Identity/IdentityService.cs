namespace SourDictionary.WebApp.Infrastructure.Services.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly HttpClient _httpClient;
        private readonly ISyncLocalStorageService _localStorage;
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public IdentityService(
            HttpClient httpClient, 
            ISyncLocalStorageService localStorage,
            AuthenticationStateProvider authenticationStateProvider)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
            _authenticationStateProvider = authenticationStateProvider;
        }


        public bool IsLoggedIn => !string.IsNullOrEmpty(GetUserToken());

        public string GetUserToken()
        {
            return _localStorage.GetToken();
        }

        public string GetUserName()
        {
            return _localStorage.GetToken();
        }

        public Guid GetUserId()
        {
            return _localStorage.GetUserId();
        }

        public async ValueTask<bool> LoginAsync(LoginUserCommand command)
        {
            string responseMessage;
            var httpResponseMessage = await _httpClient.PostAsJsonAsync("/api/User/Login", command);

            if (httpResponseMessage is not null && !httpResponseMessage.IsSuccessStatusCode)
            {
                if (httpResponseMessage.StatusCode == HttpStatusCode.BadRequest)
                {
                    responseMessage = await httpResponseMessage.Content.ReadAsStringAsync();
                    
                    var validation = JsonSerializer.Deserialize<ValidationResponseModel>(responseMessage, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    responseMessage = validation.FlattenErrors;
                    throw new DatabaseValidationException(responseMessage);
                }

                return false;
            }


            responseMessage = await httpResponseMessage.Content.ReadAsStringAsync();
            var response = JsonSerializer.Deserialize<LoginUserViewModel>(responseMessage);

            if (!string.IsNullOrEmpty(response.Token)) // login success
            {
                _localStorage.SetToken(response.Token);
                _localStorage.SetUsername(response.UserName);
                _localStorage.SetUserId(response.Id);

                ((AuthStateProvider)_authenticationStateProvider).NotifyUserLogin(response.UserName, response.Id);

                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", response.UserName);

                return true;
            }

            return false;
        }

        public void Logout()
        {
            _localStorage.RemoveItem(LocalStorage.TokenName);
            _localStorage.RemoveItem(LocalStorageExtension.UserName);
            _localStorage.RemoveItem(LocalStorageExtension.UserId);

            ((AuthStateProvider)_authenticationStateProvider).NotifyUserLogout();
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }
    }
}
