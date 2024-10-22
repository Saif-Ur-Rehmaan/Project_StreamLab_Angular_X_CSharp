using System.ComponentModel.DataAnnotations;

namespace Api.CORE.ViewModels.MovieViewModels
{
    public class MovieCategoryViewModel
    {
        [Required, MaxLength(100)]
        public required string Name { get; set; }

    }
}
