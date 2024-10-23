using Api.CORE.Models.MovieModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace Api.CORE.ViewModels.MovieViewModels
{
    public class MovieViewModel
    {
        
        [Required]
        public required MovieCategoryViewModel MovieCategory { get; set; }
        [Required]
        public required string Title { get; set; }
        //[Required]
        //public required IFormFile ThumbnailFile { get; set; }
        //[Required]
        //public required IFormFile MovieFile { get; set; }

        [Required, MaxLength(100)]
        public required string Language { get; set; }

        [AllowNull, DefaultValue(false)]
        public bool? TvPg { get; set; }
        [AllowNull]
        public string? Description { get; set; }
        [Required, MaxLength(100)]
        public required string Cast { get; set; }

        [AllowNull, DataType(DataType.Text)]
        public string Tags { get; set; }

        [AllowNull]
        public int Views { get; set; }
        [Required]
        public required DateTime RunTime { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
    }
}
