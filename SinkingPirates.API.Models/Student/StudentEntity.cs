using System;
using System.ComponentModel.DataAnnotations;

namespace SinkingPirates.API.Models
{
    public class StudentEntity
    {
        public int StudentId { get; set; }
        public int UserId { get; set; }
        public int? ClassId { get; set; }
        public int EntryCreatedByUserId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public decimal Grade { get; set; }
        public DateTime? StudentCreatedUTC { get; set; }
        public int? StudentLastEditByUserId { get; set; }
        public DateTime? StudentLastEditUTC { get; set; }
        public int EntryId { get; set; }
        public int EntryStudentId { get; set; }
        public bool Contacted { get; set; }
        public DateTime? DatesContacted { get; set; }
        public DateTime? RecentContactDateUTC { get; set; }
        public DateTime? EntryCreatedUTC { get; set; }
        public int? EntryLastEditByUserId { get; set; }
        public string Note { get; set; }
        // public int EntryStudentId { get; set; }

    }
}