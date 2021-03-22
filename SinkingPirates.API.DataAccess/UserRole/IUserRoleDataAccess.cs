using System;
using System.Threading.Tasks;

namespace SinkingPirates.API.DataAccess
{
    public interface IUserRoleDataAccess
    {
        Task<int> GetUserRoleId(int userId);
    }
}
