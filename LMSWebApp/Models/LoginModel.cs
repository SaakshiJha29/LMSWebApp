using System.ComponentModel.DataAnnotations;

namespace LMSWebApp.Models
{
    public class LoginModel
    {
        [Required]
        public string? RollNo { get; set; }
    }
}
