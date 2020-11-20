using ForumDocument.Entities;
using ForumDocument.Entities.DatabaseContext;
using ForumDocument.Interfaces;
using ForumDocument.Models;
using System.Threading.Tasks;

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

        /// <summary>
        /// lưu thông tin user vào app khi đăng ký
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<int> saveUserAsync(UserRegister user)
        {
            var newUser = new User();
            newUser.UserID = user.id;
            newUser.FullName = user.name;
            newUser.Email = user.email;
            newUser.Point = 100;
            //newUser.Role = user.listRoles;


            _context.Users.Add(newUser);
            var result = await _context.SaveChangesAsync();

            return result;
        }
    }
}
