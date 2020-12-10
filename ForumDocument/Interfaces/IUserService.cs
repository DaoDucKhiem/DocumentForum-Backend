using ForumDocument.Entities;
using ForumDocument.Models;
using System.Threading.Tasks;

namespace ForumDocument.Interfaces
{
    public interface IUserService
    {
        Task<UserLoginInfo> GetUserLoginInfoAsync();

        Task<int> saveUserAsync(UserRegister user);
        Task<bool> UpdatePointAfterDownload(User user, Document document);
    }
}
