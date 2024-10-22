using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Nodes;

namespace Api.CORE.Models.MovieModels
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public required MovieCategory MovieCategory { get; set; }
        [Required]
        public required string Title { get; set; }
        [Required, DataType(DataType.Text)]
        public required string Thumbnail { get; set; }
        [Required, DataType(DataType.Text)]
        public required string MoviePath { get; set; }

        [Required, MaxLength(100)]
        public required string Language { get; set; }

        [AllowNull,DefaultValue(false)]
        public bool? TvPg { get; set; }
        [AllowNull]
        public string? Description { get; set; }
        [Required, MaxLength(100)]
        public required string Cast { get; set; }
   
        [AllowNull,DataType(DataType.Text)]
        public string Tags { get; set; }

        [AllowNull]
        public  int Views { get; set; }
        [Required]
        public required TimeOnly RunTime { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }

}
     
}
