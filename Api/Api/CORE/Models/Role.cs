using System.ComponentModel.DataAnnotations;

namespace Api.CORE.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name =string.Empty;
    }
}
