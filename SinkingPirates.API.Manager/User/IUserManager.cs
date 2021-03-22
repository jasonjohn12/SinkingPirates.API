using System;
using System.Threading.Tasks;
using SinkingPirates.API.Models;
using SinkingPirates.API.Models.User;

namespace SinkingPirates.API.Manager.User
{
    public interface IUserManager
    {
        object LoginUser(UserToLogin userToLogin);

        Task<AppUser> GetUserByUsername(string username);
        Task<UserDto> CreateUser(UserToRegister userToRegister);
        

    }
}
