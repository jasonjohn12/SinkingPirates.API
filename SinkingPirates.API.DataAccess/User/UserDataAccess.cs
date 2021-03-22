using System;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using DataAccess;
using Microsoft.Extensions.Configuration;
using SinkingPirates.API.Models;
using SinkingPirates.API.Models.User;

namespace SinkingPirates.API.DataAccess
{
    public class UserDataAccess : BaseRepository, IUserDataAccess
    {
        public UserDataAccess(IConfiguration configuration) : base(configuration, "SQLite")
        {

        }

        public async Task<AppUser> CreateUser(AppUser appUser)
        {
            var query = @"INSERT INTO Users (UserName, PasswordHash,PasswordSalt, CreateAtDateUTC, LastActive) Values(@UserName, @PasswordHash, @PasswordSalt,@CreateAt, @LastActive)";

            DynamicParameters _params = new DynamicParameters(new
            {
                UserName = appUser.UserName,
                PasswordHash = appUser.PasswordHash,
                PasswordSalt = appUser.PasswordSalt,
                CreateAt = DateTime.UtcNow,
                LastActive = DateTime.UtcNow
            });
            await ExecuteAsync(sql: query, param: _params);
            return appUser;
           
        }

        public async Task<UserToRegister> GetUserAccessLevel(int userId)
        {
            var query = @"SELECT  FROM User WHERE UserId = @UserId";
            DynamicParameters _params = new DynamicParameters(new
            {
                UserId = userId
            });

            var user = await QueryAsync<UserToRegister>(query, param: _params);
            return user.FirstOrDefault();
        }

        public async Task<UserDto> GetUserbyUserName(string username)
        {
            var query = @"SELECT  FROM User WHERE UserName = @UserName";
            DynamicParameters _params = new DynamicParameters(new
            {
                UserName = username
            });

            var user = await QueryAsync<UserDto>(query, param: _params);
            return user.FirstOrDefault();
        }
    }
}
