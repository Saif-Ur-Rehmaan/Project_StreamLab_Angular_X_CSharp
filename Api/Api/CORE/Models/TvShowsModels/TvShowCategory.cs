using System.ComponentModel.DataAnnotations;

namespace Api.CORE.Models.TvShowModels
{
    public class TvShowCategory
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public required string Name {  get; set; }

    }
}
