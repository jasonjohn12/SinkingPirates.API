using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SinkingPirates.API.Manager;
using SinkingPirates.API.Manager.User;
using SinkingPirates.API.Models;
using SinkingPirates.API.Models.User;

namespace SinkingPirates.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserManager _userManager;

        public AuthController(IUserManager userManager)
        {
            _userManager = userManager;
        }
        //[HttpPost("login")]
        //public IActionResult Login(UserToLogin userToLogin)
        //{

        //    //  var user = await _context.Users.SingleOrDefaultAsync(x => x.UserName == loginDto.Username);
        //    var user = _userManager.GetUser();
        //    if (user == null) return Unauthorized("Invalid Username");

        //    using var hmac = new HMACSHA512(user.PasswordSalt);

        //    var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

        //    for (int i = 0; i < computedHash.Length; i++)
        //    {
        //        if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid Password");

        //    }
        //    return new UserDto
        //    {
        //        Username = user.UserName,
        //        Token = _tokenService.CreateToken(user)
        //    };
        //    //var user = _userManager.LoginUser(userToLogin);

        //    // return Ok(user);

        //    //  var user = _userManager.Authenticate(userToLogin);
        //}

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(UserToRegister userToRegister)
        {
            //if (await UserExists(userToRegister.Username)) return BadRequest("Username is taken");
              var user = await _userManager.CreateUser(userToRegister);
            return user;
            //return new UserDto
            //{
            //    UserName = userToRegister.Username,
            //    Token = _tokenService.CreateToken(user)
            //};
        }

        //private async Task<bool> UserExists(string username)
        //{
        //    return await _context.Users.AnyAsync(x => x.UserName == username.ToLower());
        //}
    }
}
