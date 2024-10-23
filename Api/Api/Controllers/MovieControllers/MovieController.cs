using Api.CORE.Models.MovieModels;
using Api.CORE.ResponseModels;
using Api.CORE.ViewModels.MovieViewModels;
using Api.Helpers;
using Api.REPOSITORY.Interfaces.MovieInterfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers.MovieControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController(IMovieRepository movieRepo,IMovieCategoryRepository mcRepo) : ControllerBase
    {
        public IMovieRepository _movieRepo = movieRepo;
        public IMovieCategoryRepository _mcRepo = mcRepo;
        protected UploadHandler uploadHandler = new ();
        // GET: api/<MovieController>
        [HttpGet]
        public IActionResult Get()
        {
            var movie = _movieRepo.GetMovies();
            return Ok(new ApiResponse() { Status = "success", Message = "Movies Retreved Successfully", Data = movie});
        }

        // GET api/<MovieController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Movie? movie= _movieRepo.FindMovie(id);
            if (movie == null) { return NotFound($"Movie OF Id {id} Doesn't Exist"); }

            return Ok(new ApiResponse() { Status = "success", Message = "Movie Retrived Successfully", Data = movie });
        }

        // POST api/<MovieController>
        [HttpPost]
        //public IActionResult Post([FromForm] MovieViewModel mvm)
        public IActionResult Post([FromForm] MovieViewModel mvm, IFormFile ThumbnailFile, IFormFile MovieFile)
        {
              if (!ModelState.IsValid) { return BadRequest(); }
            //checking if movieCategoryExist
            MovieCategory? movieCategory = _mcRepo.FindMovieCategory(mvm.MovieCategory.Name);
            if (movieCategory == null) { return NotFound($"Movie Category With Name:'{mvm.MovieCategory.Name}' Doesn't Exist"); }
            //checking duplicate title of movie 
            Movie? m = _movieRepo.FindMovie(mvm.Title);
            if (m != null) { return NotFound($"Movie With Title:'{mvm.Title}' Already Exist"); }
            //------------------- creating movie ----------------

            //uploading movie and thumbnail 
            string MoviePath;
            string ThumbnailPath;
            try
            {
                ThumbnailPath = uploadHandler.UploadImage(ThumbnailFile);
                MoviePath = uploadHandler.UploadVideo(MovieFile);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
           
            //Creating A new Record
            Movie newMovie = _movieRepo.CreateMovie(new Movie()
            {
                //set props
                Title = mvm.Title,
                Cast = mvm.Cast,
                Language = mvm.Language,
                MovieCategory = movieCategory,
                MoviePath = MoviePath,
                Thumbnail = ThumbnailPath,
                RunTime = TimeOnly.FromDateTime(mvm.RunTime),
                Description = mvm.Description,
                ReleaseDate = mvm.ReleaseDate,
                Tags = mvm.Tags,
                TvPg = mvm.TvPg,
                Views = mvm.Views,

            });
            return CreatedAtAction(nameof(Get), new { id = newMovie.Id}, new ApiResponse()
            {
                Status = "success",
                Message = "Movie Created Successfully",
                Data = newMovie
            });
        }

        // PUT api/<MovieController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromForm] MovieViewModel mvm, IFormFile? ThumbnailFile, IFormFile? MovieFile)
        {
            // Check if the movie exists
            var existingMovie = _movieRepo.FindMovie(id);
            if (existingMovie == null)
            {
                return NotFound($"Movie with ID: {id} not found.");
            }
            //checking duplicate title of movie 
            Movie? m = _movieRepo.FindMovieExcept(mvm.Title,id);
            if (m != null) { return NotFound($"Movie With Title:'{mvm.Title}' Already Exist"); }

            //checking if movieCategoryExist

            MovieCategory? movieCategory = _mcRepo.FindMovieCategory(mvm.MovieCategory.Name);
            if (movieCategory == null) { return NotFound($"Movie Category With Name:'{mvm.MovieCategory.Name}' Doesn't Exist"); }


            // Update movie properties
            existingMovie.Title = mvm.Title;
            existingMovie.MovieCategory = movieCategory;
            existingMovie.Cast = mvm.Cast;
            existingMovie.Language = mvm.Language;
            existingMovie.Description = mvm.Description;
            existingMovie.RunTime = TimeOnly.FromDateTime(mvm.RunTime);
            existingMovie.ReleaseDate = mvm.ReleaseDate;
            existingMovie.Tags = mvm.Tags;
            existingMovie.TvPg = mvm.TvPg;
            existingMovie.Views = mvm.Views;

            // Update file paths if new files are uploaded
            
            try
            {
                if (ThumbnailFile != null)
                {//-------------------------------------- ERROR: on update old file is not deleting----------------------------
                  
                    try
                    {
                      uploadHandler.DeleteVideo(existingMovie.Thumbnail);
                      
                    }
                    catch (Exception e)
                    {
                        return BadRequest($" Error while deleting old File {e.Message}");
                    }
                     existingMovie.Thumbnail = uploadHandler.UploadImage(ThumbnailFile);
                }
                if (MovieFile != null)
                {
                    try
                    {
                        uploadHandler.DeleteImage(existingMovie.MoviePath);

                    }
                    catch (Exception e)
                    {
                        return BadRequest($" Error while deleting old File {e.Message}");
                    }
                    existingMovie.MoviePath = uploadHandler.UploadVideo(MovieFile);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            // Save changes
            _movieRepo.UpdateMovie(existingMovie);

            return Ok(new ApiResponse()
            {
                Status = "success",
                Message = "Movie updated successfully.",
                Data = existingMovie
            });
        }

        // DELETE api/<MovieController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Check if the movie exists
            var existingMovie = _movieRepo.FindMovie(id);
            if (existingMovie == null)
            {
                return NotFound($"Movie with ID: {id} not found.");
            }
            //deleting the movie
       
            try
            {
               uploadHandler.DeleteVideo(existingMovie.MoviePath);            
               uploadHandler.DeleteImage(existingMovie.Thumbnail);            
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            // Remove the movie from the repository
            Movie DeletedMovie= _movieRepo.DeleteMovie(existingMovie);

            return Ok(new ApiResponse()
            {
                Status = "success",
                Message = "Movie deleted successfully.",
                Data= DeletedMovie
            });
        }

    }
}
