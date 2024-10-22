using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Api.CORE.Models.TvShowModels
{
    public class TvShow
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public required TvShowCategory Category { get; set; }
        [Required]
        public required string Title { get; set; }
        
        [Required,DataType(DataType.Text)]
        public required string Thumbnail { get; set; }
        
        [Required,DataType(DataType.Text)]
        public required string TvShowDescription { get; set; }
        

    }

}
