namespace SourDictionary.WebApp.Infrastructure.Extensions
{
    public static class LocalStorageExtension
    {
        public const string TokenName = "token";
        public const string UserName = "username";
        public const string UserId = "userid";

        public static bool IsUserLoggedIn(this ISyncLocalStorageService localStorageService)
        {
            return !string.IsNullOrEmpty(GetToken(localStorageService));
        }

        public static string GetUserName(this ISyncLocalStorageService localStorageService)
        {
            return localStorageService.GetItem<string>(UserName);
        }

        public static async ValueTask<string> GetUserNameAsync(this ILocalStorageService localStorageService)
        {
            return await localStorageService.GetItemAsync<string>(UserName);
        }

        public static void SetUsername(this ISyncLocalStorageService localStorageService, string value)
        {
            localStorageService.SetItem(UserName, value);
        }

        public static async ValueTask SetUsernameAsync(this ILocalStorageService localStorageService, string value)
        {
            await localStorageService.SetItemAsync(UserName, value);
        }

        public static Guid GetUserId(this ISyncLocalStorageService localStorageService)
        {
            return localStorageService.GetItem<Guid>(UserId);
        }

        public static void SetUserId(this ISyncLocalStorageService localStorageService, Guid id)
        {
            localStorageService.SetItem(UserId, id);
        }

        public static async ValueTask SetUserIdAsync(this ILocalStorageService localStorageService, Guid id)
        {
            await localStorageService.SetItemAsync(UserId, id);
        }

        public static async ValueTask<Guid> GetUserIdAsync(this ILocalStorageService localStorageService)
        {
            return await localStorageService.GetItemAsync<Guid>(UserId);
        }

        public static string GetToken(this ISyncLocalStorageService localStorageService) => localStorageService.GetItem<string>(TokenName);

        public static async ValueTask<string> GetTokenAsync(this ILocalStorageService localStorageService) => await localStorageService.GetItemAsync<string>(TokenName);

        public static void SetToken(this ISyncLocalStorageService localStorageService, string value)
        {
            localStorageService.SetItem(LocalStorage.TokenName, value);
        }

        public static async ValueTask SetTokenAsync(this ILocalStorageService localStorageService, string value)
        {
            await localStorageService.SetItemAsync(TokenName, value);
        }
    }
}
