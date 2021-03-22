using System;
using System.Threading.Tasks;
using SinkingPirates.API.Models;
using SinkingPirates.API.Models.User;

namespace SinkingPirates.API.DataAccess
{
    public interface IUserDataAccess
    {
       Task<UserToRegister> GetUserAccessLevel(int userId);
        Task<UserDto> GetUserbyUserName(string username);
        Task<AppUser> CreateUser(AppUser appUser);
    };
}
