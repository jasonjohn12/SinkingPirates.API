using System;
namespace SinkingPirates.API.Models
{
    public class Entry
    {
        public int EntryId { get; set; }
        public bool Contacted { get; set; }
        public DateTime DatesContacted { get; set; }
        public string Note { get; set; }
        public int StudentId { get; set; }
    }
}
