using ForumDocument.Entities;
using ForumDocument.Models;
using System;
using System.Threading.Tasks;

namespace ForumDocument.Interfaces
{
    public interface IUserService
    {
        Task<UserLoginInfo> GetUserLoginInfoAsync();

        Task<int> saveUserAsync(UserRegister user);

        Task<User> GetUserInfor(Guid id);
        Task<bool> UpdatePointAfterDownload(PosterParam posterParam);
    }
}
