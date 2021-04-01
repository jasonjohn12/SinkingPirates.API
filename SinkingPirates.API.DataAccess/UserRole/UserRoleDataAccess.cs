using System;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using DataAccess;
using Microsoft.Extensions.Configuration;
using SinkingPirates.API.Models;

namespace SinkingPirates.API.DataAccess
{
    public class UserRoleDataAccess : BaseRepository, IUserRoleDataAccess
    {
        public UserRoleDataAccess(IConfiguration configuration) : base(configuration, "Data Source=SQLite")
        {

        }
        public async Task<int> GetUserRoleId(int userId)
        {
            var query = @"SELECT RoleId FROM UserRole WHERE UserId = @UserId";
            DynamicParameters _params = new DynamicParameters(new
            {
                UserId = userId
            });

            var roleId = await QueryAsync<int>(query, param: _params);
            return roleId.FirstOrDefault();
        }
    }
}
