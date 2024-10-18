using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Api.CORE.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required Role Role { get; set; } // Assuming a relationship

        [Required, MaxLength(50)]
        public required string UserName { get; set; }

        [Required, MaxLength(100),EmailAddress]
        public required string Email { get; set; }

        [Required, DataType(DataType.Text)] 
        public required string  Password { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }


    }

}
