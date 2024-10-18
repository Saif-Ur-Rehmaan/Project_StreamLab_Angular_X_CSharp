using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Api.CORE.Models.Movie
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public required string Title { get; set; }
        [Required, DataType(DataType.Text)]
        public required string Thumbnail { get; set; }
        [Required, DataType(DataType.Text)]
        public required string MoviePath { get; set; }

        [Required, MaxLength(100)]
        public string Language = string.Empty;

        [AllowNull]
        public bool TvPg = false;
        [AllowNull]
        public string Description=string.Empty;


    }
}
