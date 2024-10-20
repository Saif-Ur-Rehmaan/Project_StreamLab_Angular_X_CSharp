using System.ComponentModel.DataAnnotations;

namespace Api.CORE.ViewModels
{
    public class UserViewModel
    { 

        [Required]
        public required RoleViewModel Role { get; set; }

        [Required, MaxLength(50)]
        public required string UserName { get; set; }

        [Required, MaxLength(100), EmailAddress]
        public required string Email { get; set; }

        [Required, DataType(DataType.Text)]
        public required string Password { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }
    }
     
}
