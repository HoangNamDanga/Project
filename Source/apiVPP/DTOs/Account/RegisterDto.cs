using System.ComponentModel.DataAnnotations;

namespace apiVPP.DTOs.Account
{
    public class RegisterDto
    {
        [Required]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "First name must be at least {2}, and maxium {1} characters")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Last name must be at least {2}, and maxium {1} characters")]
        public string LastName { get; set; }
        [Required]
        [RegularExpression("^\\w+@[a-zA-Z_]+?\\.[a-zA-Z]{2,3}$", ErrorMessage = " Invalid email address")]
        public string Email { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Username must be at least {2}, and maximum {1} characters")]
        public string UserName { get; set; }



        [Range(1, int.MaxValue, ErrorMessage = "SuperiorID must be greater than 0")] // Kiểm tra giá trị phải lớn hơn 0
        public int? SuperiorID { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 6, ErrorMessage = "Password must be at least {2}, and maxium {1} characters")]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "RoleId must be greater than 0")] // Kiểm tra giá trị phải lớn hơn 0
        public int RoleId { get; set; } // Trường để chỉ định vai trò
    }
}
