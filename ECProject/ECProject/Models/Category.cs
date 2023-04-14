using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ECProject.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Min 3 Char Required !"), MaxLength(45, ErrorMessage = "Name Must Be Less Then 45 Char")]
        [Display(Name = "Category Name")]
        public string CName { get; set; }

        public string slug { get; set; }
    }
}
