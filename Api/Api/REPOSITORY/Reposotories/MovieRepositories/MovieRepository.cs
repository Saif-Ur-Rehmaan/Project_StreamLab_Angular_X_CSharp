using Api.CORE;
using Api.CORE.Models.MovieModels;
using Api.REPOSITORY.Interfaces.MovieInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.REPOSITORY.Reposotories.MovieRepositories
{
    public class MovieRepository(StreamLabContext entities) : IMovieRepository
    {

        protected StreamLabContext _entities = entities;
        public Movie CreateMovie(Movie movie)
        {
            var entity = _entities.Movies.Add(movie);
            _entities.SaveChanges();
            return entity.Entity;
        }

        public Movie DeleteMovie(Movie movie)
        {
            _entities.Movies.Remove(movie);
            _entities.SaveChanges();
            return movie;
        }

        public Movie? FindMovie(int id)
        {
            return _entities.Movies.Include(x => x.MovieCategory).FirstOrDefault(x => x.Id == id);
        }

        public Movie? FindMovie(string MovieTitle)
        {
            return _entities.Movies.Include(x => x.MovieCategory).FirstOrDefault(x => x.Title == MovieTitle);
        }

        public Movie? FindMovieExcept(string MovieTitle, int ExceptCategoryId)
        {
            return _entities.Movies.Include(x => x.MovieCategory).FirstOrDefault(x => x.Title == MovieTitle&& x.Id!=ExceptCategoryId);
        }



        public IEnumerable<Movie> GetMovies()
        {
            var movies = _entities.Movies.Include(x => x.MovieCategory).ToList();
            return movies;
        }

        public Movie UpdateMovie( Movie movie)
        {
            var emovie = _entities.Movies.Update(movie);
           
                _entities.SaveChanges();
            
            return emovie.Entity;
        }
    }
}
