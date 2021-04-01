using System;
namespace SinkingPirates.API.Models
{
    public class Entry
    {
        public int Id { get; set; }
        public bool Contacted { get; set; }
        public int CreatedByUserId { get; set; }
        public DateTime? CreatedAtDateUTC { get; set; }
        public string Note { get; set; }
        public int StudentId { get; set; }
    }
}
