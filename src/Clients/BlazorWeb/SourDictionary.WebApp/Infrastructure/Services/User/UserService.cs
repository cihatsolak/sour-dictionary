namespace SourDictionary.WebApp.Infrastructure.Services.User
{
    public class UserService : IUserService
    {
        private readonly HttpClient _client;

        public UserService(HttpClient client)
        {
            _client = client;
        }

        public async Task<UserDetailViewModel> GetUserDetailAsync(Guid? id)
        {
            var userDetail = await _client.GetFromJsonAsync<UserDetailViewModel>($"/api/user/{id}");
            return userDetail;
        }

        public async Task<UserDetailViewModel> GetUserDetailAsync(string userName)
        {
            var userDetail = await _client.GetFromJsonAsync<UserDetailViewModel>($"/api/user/username/{userName}");
            return userDetail;
        }

        public async ValueTask<bool> UpdateUserAsync(UserDetailViewModel user)
        {
            var res = await _client.PostAsJsonAsync($"/api/user/update", user);
            return res.IsSuccessStatusCode;
        }

        public async ValueTask<bool> ChangeUserPasswordAsync(string oldPassword, string newPassword)
        {
            ChangeUserPasswordCommand command = new(null, oldPassword, newPassword);
            var httpResponseMessage = await _client.PostAsJsonAsync($"/api/User/ChangePassword", command);

            if (httpResponseMessage is null && !httpResponseMessage.IsSuccessStatusCode)
            {
                if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    var responseMessage = await httpResponseMessage.Content.ReadAsStringAsync();
                    var validation = JsonSerializer.Deserialize<ValidationResponseModel>(responseMessage);
                    responseMessage = validation.FlattenErrors;
                    throw new DatabaseValidationException(responseMessage);
                }

                return false;
            }

            return httpResponseMessage.IsSuccessStatusCode;
        }
    }
}
