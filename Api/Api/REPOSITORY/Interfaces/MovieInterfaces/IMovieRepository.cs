using Api.CORE.Models;
using Api.CORE.Models.MovieModels;

namespace Api.REPOSITORY.Interfaces.MovieInterfaces
{
    public interface IMovieRepository
    {
        public IEnumerable<Movie> GetMovies();

        public Movie? FindMovie(int id);
        public Movie? FindMovie(string MovieTitle   );
        public Movie? FindMovieExcept(string MovieTitle ,int id); 

        public Movie CreateMovie(Movie movie);

        public Movie UpdateMovie(  Movie movie);

        public Movie DeleteMovie(Movie movie);
    }

}
