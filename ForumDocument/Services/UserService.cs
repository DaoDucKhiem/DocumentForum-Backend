using ForumDocument.Entities;
using ForumDocument.Entities.DatabaseContext;
using ForumDocument.Interfaces;
using ForumDocument.Models;
using Microsoft.EntityFrameworkCore;
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
        /// <summary>
        /// Cập nhật điểm người dùng
        /// </summary>
        /// <param name="user"></param>
        /// <param name="document"></param>
        /// <returns></returns>
        public async Task<bool> UpdatePointAfterDownload(User user, Document document)
        {
            var reducePoint = new User();
            var increasePoint = new User();
            bool res;
            increasePoint = await _context.Users.SingleOrDefaultAsync(x => x.UserID == user.UserID);
            reducePoint = await _context.Users.SingleOrDefaultAsync(x => x.UserID == document.UserID);
            if (increasePoint != null && reducePoint != null)
            {
                if(reducePoint.Point - document.Point > 0)
                {
                    increasePoint.Point = increasePoint.Point + document.Point;
                    reducePoint.Point = reducePoint.Point - document.Point;
                    _context.Entry(increasePoint).State = EntityState.Modified;
                    _context.Entry(reducePoint).State = EntityState.Modified;
                    _context.SaveChanges();
                    res = true;
                }
                else
                {
                    res = false;
                }
            }
            else {
                res = false;
             }
            return res;
        }
    }
}
