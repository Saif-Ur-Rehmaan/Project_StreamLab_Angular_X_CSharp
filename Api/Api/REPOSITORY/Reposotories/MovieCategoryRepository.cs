
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
               var entity= _entities.MovieCategories.Add(movieCategory);
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

            // Get all Movie Categories
            public IEnumerable<MovieCategory> GetMovieCategories()
            {
                return [.. _entities.MovieCategories];  
            }

            // Update Movie Category
            public MovieCategory UpdateMovieCategory(int id, MovieCategory movieCategory)
            {
                var categoryToUpdate = FindMovieCategory(id);
                if (categoryToUpdate != null)
                {
                    categoryToUpdate.Name = movieCategory.Name; 
                    _entities.SaveChanges(); 

                }
                
                return movieCategory;
            }
         

    }
}
