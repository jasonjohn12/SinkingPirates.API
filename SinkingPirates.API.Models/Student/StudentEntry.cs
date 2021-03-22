using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SinkingPirates.API.Models
{
    public class StudentEntry
    {
        public int StudentId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public decimal Grade { get; set; }

        public ICollection<Entry> Entries { get; set; } = new List<Entry>();
    }
}
