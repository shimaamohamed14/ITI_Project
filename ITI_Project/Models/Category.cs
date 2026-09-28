using System.ComponentModel.DataAnnotations;

namespace ITI_Project.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required(ErrorMessage ="Name is required")]
        [StringLength(50,ErrorMessage ="Name must be between 3 and 50", MinimumLength =3)]
        public string Name { get; set; }

        [StringLength(300, ErrorMessage = "Description must be between 3 and 300", MinimumLength = 3)]
        public string? Description { get; set; }
        public ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }
}
