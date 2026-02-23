using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Students
    {

        [Key]
        public int StudentID { get; set; }

        [Required]
        public string? RollNo { get; set; }

        [Required]
        public string? FullName { get; set; }

        [Required]
        public string? Department { get; set; }

    }
}
