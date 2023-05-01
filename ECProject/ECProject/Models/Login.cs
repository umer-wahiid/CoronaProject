using System.ComponentModel.DataAnnotations;

namespace ECProject.Models
{
    public class Login
    {
        public int id { get; set; }

        [Display(Name = "User Name")]
        [Required]
        [MinLength(3, ErrorMessage = "Min 3 Char Req"), MaxLength(50)]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [Required]
        [MinLength(3, ErrorMessage = "Min 3 Char Req"), MaxLength(50)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Required]
        [Compare("Password", ErrorMessage = "Password Mismatch")]
        [MinLength(3, ErrorMessage = "Min 3 Char Req"), MaxLength(50)]
        public string CPassword { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required]
        [MinLength(3, ErrorMessage = "Min 3 Char Req"), MaxLength(50)]
        public string Email { get; set; }

        [Required]
        [MinLength(11, ErrorMessage = "Min 11 Char Req"), MaxLength(20)]
        public string PhoneNo { get; set; }

        [Display(Name = "Home Address")]
        [Required]
        [MinLength(10, ErrorMessage = "Min 10 Char Req"), MaxLength(250)]
        public string HAddress { get; set; }
    }
}
