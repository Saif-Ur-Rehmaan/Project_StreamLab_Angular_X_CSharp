using System.ComponentModel.DataAnnotations;

namespace Api.CORE.Models.MovieModels
{
    public class MovieCategory
    {
        [Key]
        public int Id { get; set; }
        [Required,MaxLength(100)]
        
        public required string Name { get; set; }

    }
}
