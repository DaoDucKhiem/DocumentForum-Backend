using ForumDocument.Entities.DatabaseContext;
using ForumDocument.Interfaces;
using ForumDocument.Models;

namespace ForumDocument.Services
{
    public class UserService : BaseService, IUserService
    {
        public UserService(DataContext context, IAuthService authenService) : base(context, authenService)
        {
        }

        public UserLoginInfo GetUserLoginInfo()
        {
            return _authenService.GetUserInfor();
        }
    }
}
