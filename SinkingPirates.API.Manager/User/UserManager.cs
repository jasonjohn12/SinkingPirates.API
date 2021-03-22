using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using SinkingPirates.API.DataAccess;
using SinkingPirates.API.Manager.TokenService;
using SinkingPirates.API.Models;
using SinkingPirates.API.Models.User;

namespace SinkingPirates.API.Manager.User
{
    public class UserManager : IUserManager
    {
        private readonly IUserDataAccess _userDataAccess;
        private readonly ITokenService _tokenService;

        public UserManager(IUserDataAccess userDataAccess, ITokenService tokenService)
        {
            _userDataAccess = userDataAccess;
            _tokenService = tokenService;
        }
        
        public async Task<UserDto> CreateUser(UserToRegister userToRegister)
        {
            using var hmac = new HMACSHA512();
            var user = new AppUser
            {
                UserName = userToRegister.Username.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userToRegister.Password)),
                PasswordSalt = hmac.Key
            };
            await _userDataAccess.CreateUser(user);
            return new UserDto
            {
                UserName = userToRegister.Username,
                Token = _tokenService.CreateToken(user)
            };

        }

        public Task<AppUser> GetUserByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public object LoginUser(UserToLogin userToLogin)
        {
            var user = new
            {
                Id = 1,
                UserName = "jjohn",
                FirstName = "Jason",
                LastName = "John",
                Email = "test@test.com"
            };

            return user;
        }
    }
}
