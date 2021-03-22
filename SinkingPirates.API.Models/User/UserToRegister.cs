using System;
using System.ComponentModel.DataAnnotations;

namespace SinkingPirates.API.Models
{
    public class UserToRegister
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [StringLength(8, MinimumLength = 4)]
        public string Password { get; set; }
    }
}
