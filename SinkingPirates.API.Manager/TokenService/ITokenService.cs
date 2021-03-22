using System;
using SinkingPirates.API.Models.User;

namespace SinkingPirates.API.Manager.TokenService
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
