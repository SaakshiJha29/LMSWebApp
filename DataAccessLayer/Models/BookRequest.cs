using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    public class BookRequest
    {
        [Key]
        public int Id { get; set; }
       
        [Required]
        public DateTime? FromDate { get; set; }
        [Required]
        public DateTime? ToDate { get; set; }
        public string? RequestStatus { get; set; } 


        [ForeignKey(nameof(AssignedStudents))]
        public int StudentID { get; set; }
        public Students? AssignedStudents { get; set; } // navigation property

  
        public int BookId { get; set; }
        public Book? AssignedBook { get; set; } // navigation property
    }
}
