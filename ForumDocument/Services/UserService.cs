using ForumDocument.Entities;
using ForumDocument.Entities.DatabaseContext;
using ForumDocument.Interfaces;
using ForumDocument.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace ForumDocument.Services
{
    public class UserService : BaseService, IUserService
    {
        public UserService(DataContext context, IAuthService authenService) : base(context, authenService)
        {
        }

        public async Task<UserLoginInfo> GetUserLoginInfoAsync()
        {
            UserLoginInfo userInfo = _authenService.GetUserInfor();
            User data = await GetUserInfor(userInfo.UserID);
            userInfo.FullName = data.FullName;
            userInfo.Point = data.Point;
            userInfo.Role = data.Role;
            return userInfo;
        }

        public async Task<User> GetUserInfor(Guid id)
        {

            return await _context.Users.FindAsync(id);
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
        public async Task<bool> UpdatePointAfterDownload(PosterParam posterParam)
        {
            var reducePoint = new User();
            var increasePoint = new User();
            var document = new Document();
            bool res;
            increasePoint = await _context.Users.SingleOrDefaultAsync(x => x.UserID == posterParam.Poster);
            reducePoint = await _context.Users.SingleOrDefaultAsync(x => x.UserID == posterParam.Downloader);
            document = await _context.Document.SingleOrDefaultAsync(x => x.DocumentID == posterParam.DocumentID);

            if (increasePoint != null && reducePoint != null && document != null)
            {
                increasePoint.Point = increasePoint.Point + posterParam.Point;
                reducePoint.Point = reducePoint.Point - posterParam.Point;
                document.DownloadCount++;
                _context.Entry(increasePoint).State = EntityState.Modified;
                _context.Entry(reducePoint).State = EntityState.Modified;
                _context.Entry(document).State = EntityState.Modified;
                _context.SaveChanges();
                res = true;
            }
            else
            {
                res = false;
            }
            return res;
        }
    }
}
