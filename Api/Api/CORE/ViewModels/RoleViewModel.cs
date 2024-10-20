using System.ComponentModel.DataAnnotations;

namespace Api.CORE.ViewModels
{
    public class RoleViewModel
    {
        [Required]
        public required string Name { get; set; }
    }
}
