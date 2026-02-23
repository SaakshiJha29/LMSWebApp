using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [Required(ErrorMessage = "Book title is required.")]
        [StringLength(150, ErrorMessage = "Title cannot exceed 150 characters.")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Book category is required.")]
        [StringLength(100, ErrorMessage = "Category cannot exceed 100 characters.")]
        public string? Category { get; set; }

        [Required(ErrorMessage = "Author name is required.")]
        [StringLength(120, ErrorMessage = "Author name cannot exceed 120 characters.")]
        public string? Author { get; set; }

        [Required(ErrorMessage = "Available copies is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Available copies must be at least 1.")]
        public int AvailableCopies { get; set; }
    }
}
