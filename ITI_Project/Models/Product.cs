using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITI_Project.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required(ErrorMessage ="Title is required")]
        [StringLength(100,ErrorMessage ="Title must be between 3 and 100 characters",MinimumLength =3)]
        public string Title { get; set; }

        [Range(1,1000000,ErrorMessage ="Price must be between 1 and 1000000 ")]
        public decimal Price { get; set; }

        [StringLength(500, ErrorMessage = "Description must be between 5 and 500 characters", MinimumLength = 5)]
        public string? Description { get; set; }

        [Range(0, 10000, ErrorMessage = "Quantity must be between 0 and 10000")]
        public int Quantity { get; set; }

        public string? ImagePath { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

    }
}
