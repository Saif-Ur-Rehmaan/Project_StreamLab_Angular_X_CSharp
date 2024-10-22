using Api.CORE.Models;
using Api.CORE.Models.MovieModels;

namespace Api.REPOSITORY.Interfaces.MovieInterfaces
{
    public interface IMovieCategoryRepository
    {
        public IEnumerable<MovieCategory> GetMovieCategories();

        public MovieCategory? FindMovieCategory(int id);
        public MovieCategory? FindMovieCategory(string CategoryName);
        public MovieCategory? FindMovieCategoryExcept(string CategoryName,int ExceptCategoryId);

        public MovieCategory CreateMovieCategory(MovieCategory movieCategory);

        public MovieCategory UpdateMovieCategory(MovieCategory movieCategory);

        public MovieCategory DeleteMovieCategory(MovieCategory movieCategory);
    }
}
