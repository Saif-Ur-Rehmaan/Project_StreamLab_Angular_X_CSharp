
using Api.CORE;
using Api.CORE.Models.Movie;
using Api.REPOSITORY.Interfaces;

namespace Api.REPOSITORY.Reposotories
{
    public class MovieCategoryRepository(StreamLabContext entities) : IMovieCategoryRepository
    {
        
            private readonly StreamLabContext _entities=entities;

         
            // Create Movie Category
            public MovieCategory CreateMovieCategory(MovieCategory movieCategory)
            {
                _entities.MovieCategories.Add(movieCategory);
                _entities.SaveChanges(); // Save changes to the database
                return movieCategory;
            }

            // Delete Movie Category
            public MovieCategory DeleteMovieCategory(MovieCategory movieCategory)
            {
                _entities.MovieCategories.Remove(movieCategory);
                _entities.SaveChanges();
                 
                return movieCategory;
            }

            // Find Movie Category by Id
            public MovieCategory FindMovieCategory(int id)
            {
                return _entities.MovieCategories.Find(id) ?? throw new Exception("Movie Category Not Found");  
            }

            // Get all Movie Categories
            public IEnumerable<MovieCategory> GetMovieCategories()
            {
                return _entities.MovieCategories.ToList();  
            }

            // Update Movie Category
            public MovieCategory UpdateMovieCategory(int id, MovieCategory movieCategory)
            {
                var categoryToUpdate = FindMovieCategory(id);
                categoryToUpdate.Name = movieCategory.Name; 
                _entities.SaveChanges(); 
                
                return categoryToUpdate;
            }
         

    }
}
