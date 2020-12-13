using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ForumDocument.Entities;
using ForumDocument.Entities.DatabaseContext;
using ForumDocument.Models;
using ForumDocument.Interfaces;
using ForumDocument.Helpers.Enumeration;

namespace ForumDocument.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userBL;

        public UsersController(IUserService userService)
        {
            _userBL = userService;
        }

        [HttpGet]
        [Route("GetUserLogin")]
        public async Task<ServiceResponse> GetUserLoginAsync()
        {
            var result = new ServiceResponse();
            try
            {
                var userData = new
                {
                    UserData = await _userBL.GetUserLoginInfoAsync(),
                };
                result.Data = userData;
            }
            catch (Exception ex)
            {
                result.OnExeption(ex);
            }
            return result;
        }

        [HttpPost]
        [Route("updatePoint")]
        public async Task<ServiceResponse> UpdatePointAfterDownload(PosterParam posterParam)
        {
            ServiceResponse result = new ServiceResponse();
            try
            {
                result.Data = await _userBL.UpdatePointAfterDownload(posterParam);
                result.Code = ServiceResponseCode.Success;
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.OnExeption(ex);
            }
            return result;
        }
        //private readonly DataContext _context;

        //public UsersController(DataContext context)
        //{
        //    _context = context;
        //}

        //// GET: api/Users
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        //{
        //    return await _context.Users.ToListAsync();
        //}

        //// GET: api/Users/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<User>> GetUser(Guid id)
        //{
        //    var user = await _context.Users.FindAsync(id);

        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    return user;
        //}

        //// PUT: api/Users/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutUser(Guid id, User user)
        //{
        //    if (id != user.UserID)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(user).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!UserExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Users
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [Route("registerUser")]
        public async Task<ActionResult<ServiceResponse>> RegisterUser(UserRegister user)
        {
            var result = new ServiceResponse();
            try
            {
                result.Data = await _userBL.saveUserAsync(user);
                result.Code = ServiceResponseCode.Success;
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.OnExeption(ex);
                return BadRequest(result);
            }
            return Ok(result);
        }

        //// DELETE: api/Users/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<User>> DeleteUser(Guid id)
        //{
        //    var user = await _context.Users.FindAsync(id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Users.Remove(user);
        //    await _context.SaveChangesAsync();

        //    return user;
        //}

        //private bool UserExists(Guid id)
        //{
        //    return _context.Users.Any(e => e.UserID == id);
        //}
    }
}
