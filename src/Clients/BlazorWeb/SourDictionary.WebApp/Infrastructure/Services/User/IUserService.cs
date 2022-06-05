
namespace SourDictionary.WebApp.Infrastructure.Services.User
{
    public interface IUserService
    {
        ValueTask<bool> ChangeUserPassword(string oldPassword, string newPassword);
        Task<UserDetailViewModel> GetUserDetail(Guid? id);
        Task<UserDetailViewModel> GetUserDetail(string userName);
        ValueTask<bool> UpdateUser(UserDetailViewModel user);
    }
}