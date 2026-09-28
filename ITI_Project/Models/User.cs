using System.ComponentModel.DataAnnotations;

namespace ITI_Project.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [StringLength(50, ErrorMessage = "First Name must be between 3 and 50 characters", MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(50,ErrorMessage = "Last Name must be between 3 and 50 characters", MinimumLength =3)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Enter a valid email address")]
        [StringLength(50, ErrorMessage = "Email must be between 3 and 50 characters", MinimumLength = 3)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [StringLength(50, ErrorMessage = "Password must be between 6 and 50 characters", MinimumLength = 6)]
        public string Password { get; set; }

    }
}
