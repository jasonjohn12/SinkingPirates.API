using System;
namespace SinkingPirates.API.Models.User
{
    public class AppUser
    {
    
        public int Id { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime CreatedAtDateUTC { get; set; } = DateTime.Now;
        public DateTime? LastActive { get; set; } = DateTime.Now;
    }
    
}
