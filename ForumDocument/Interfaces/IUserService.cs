using ForumDocument.Entities;
using ForumDocument.Models;
using System.Threading.Tasks;

namespace ForumDocument.Interfaces
{
    public interface IUserService
    {
        UserLoginInfo GetUserLoginInfo();

        Task<int> saveUserAsync(UserRegister user);
        Task<bool> UpdatePointAfterDownload(User user, Document document);
    }
}
