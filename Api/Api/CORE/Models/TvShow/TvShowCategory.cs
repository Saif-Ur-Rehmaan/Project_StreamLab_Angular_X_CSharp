using System.ComponentModel.DataAnnotations;

namespace Api.CORE.Models.TvShow
{
    public class TvShowCategory
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public required string Name = string.Empty;

    }
}
