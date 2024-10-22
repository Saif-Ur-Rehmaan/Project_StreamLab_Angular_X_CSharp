using System.ComponentModel.DataAnnotations;

namespace Api.CORE.Models.TvShowModels
{
    public class TvShowEpisode
    {
        [Key] 
        public int Id { get; set; }
        [Required]
        public required TvShow TvShow { get; set; }
        [Required]
        public required TvShowSeason TvShowSeason { get; set; }

        [Required,DataType(DataType.Text)]
        public required string Thumbnail { get; set; }

        [Required]
        public required int Views { get; set; }
        [Required]
        public required TimeOnly RunTime { get; set; }
    }
}
