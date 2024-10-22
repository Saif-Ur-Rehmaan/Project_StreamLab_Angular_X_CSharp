using Api.CORE.Models;
using Api.CORE.Models.MovieModels;

namespace Api.REPOSITORY.Interfaces.MovieInterfaces
{
    public interface IMovieRepository
    {
        public IEnumerable<Movie> GetMovies();

        public Movie? FindMovie(int id);
        public Movie? FindMovie(string MovieTitle   );
        public Movie? FindMovieCategoryExcept(string MovieTitle, int ExceptCategoryId);

        public Movie CreateMovie(Movie movie);

        public Movie UpdateMovie(int id, Movie movie);

        public Movie DeleteMovie(Movie movie);
    }

}
