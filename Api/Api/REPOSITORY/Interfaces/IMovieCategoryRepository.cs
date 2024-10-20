using Api.CORE.Models;
using Api.CORE.Models.Movie;

namespace Api.REPOSITORY.Interfaces
{
    public interface IMovieCategoryRepository
    {
        public IEnumerable<MovieCategory> GetMovieCategories();

        public MovieCategory? FindMovieCategory(int id);

        public MovieCategory CreateMovieCategory(MovieCategory movieCategory);

        public MovieCategory UpdateMovieCategory(int id, MovieCategory movieCategory);

        public MovieCategory DeleteMovieCategory(MovieCategory movieCategory);
    }
}
