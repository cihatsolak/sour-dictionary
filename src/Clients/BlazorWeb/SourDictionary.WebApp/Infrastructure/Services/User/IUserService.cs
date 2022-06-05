namespace SourDictionary.WebApp.Infrastructure.Services.User
{
    public interface IUserService
    {
        ValueTask<bool> ChangeUserPasswordAsync(string oldPassword, string newPassword);
        Task<UserDetailViewModel> GetUserDetailAsync(Guid? id);
        Task<UserDetailViewModel> GetUserDetailAsync(string userName);
        ValueTask<bool> UpdateUserAsync(UserDetailViewModel user);
    }
}