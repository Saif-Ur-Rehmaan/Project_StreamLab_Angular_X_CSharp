using Api.CORE;
using Api.CORE.Models.MovieModels;
using Api.REPOSITORY.Interfaces.MovieInterfaces;

namespace Api.REPOSITORY.Reposotories.MovieRepositories
{
    public class MovieCategoryRepository(StreamLabContext entities) : IMovieCategoryRepository
    {

        private readonly StreamLabContext _entities = entities;


        // Create Movie Category
        public MovieCategory CreateMovieCategory(MovieCategory movieCategory)
        {
            var entity = _entities.MovieCategories.Add(movieCategory);
            _entities.SaveChanges(); // Save changes to the database
            return entity.Entity;
        }

        // Delete Movie Category
        public MovieCategory DeleteMovieCategory(MovieCategory movieCategory)
        {
            _entities.MovieCategories.Remove(movieCategory);
            _entities.SaveChanges();

            return movieCategory;
        }

        // Find Movie Category by Id
        public MovieCategory? FindMovieCategory(int id)
        {
            return _entities.MovieCategories.Find(id);
        }
        public MovieCategory? FindMovieCategory(string CategoryName)
        {
            return _entities.MovieCategories.FirstOrDefault(x=>x.Name==CategoryName);
        }

        public MovieCategory? FindMovieCategoryExcept(string CategoryName, int ExceptCategoryId)
        {
            return _entities.MovieCategories.FirstOrDefault(x => x.Name == CategoryName && x.Id!=ExceptCategoryId);
        }

        // Get all Movie Categories
        public IEnumerable<MovieCategory> GetMovieCategories()
        {
            return [.. _entities.MovieCategories];
        }

        // Update Movie Category
        public MovieCategory UpdateMovieCategory(MovieCategory movieCategory)
        {
            var result = _entities.MovieCategories.Update(movieCategory);
            _entities.SaveChanges();

            return result.Entity;
        }


    }
}
