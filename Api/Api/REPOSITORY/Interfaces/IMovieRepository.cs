using Api.CORE.Models;
using Api.CORE.Models.Movie;

namespace Api.REPOSITORY.Interfaces
{
    public interface IMovieRepository
    {
        public IEnumerable<Movie> GetMovies();

        public Movie FindMovie(int id);

        public Movie CreateMovie(Movie movie);

        public Movie UpdateMovie(int id, Movie movie);

        public Movie DeleteMovie(Movie movie);
    }
    
}
