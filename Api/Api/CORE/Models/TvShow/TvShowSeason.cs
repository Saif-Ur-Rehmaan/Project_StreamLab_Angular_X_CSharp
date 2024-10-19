using System.ComponentModel.DataAnnotations;

namespace Api.CORE.Models.TvShow
{
    public class TvShowSeason
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public required string Name { get; set; }
        [Required]
        public required int SeasonNumber { get; set; }

        [Required,DataType(DataType.Text)]
        public required string SeasonDescription { get; set; }
    }
}
