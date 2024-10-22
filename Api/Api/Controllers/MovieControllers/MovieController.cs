using Api.CORE.Models.MovieModels;
using Api.CORE.ResponceModels;
using Api.CORE.ViewModels.MovieViewModels;
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

        // GET: api/<MovieController>
        [HttpGet]
        public IActionResult Get()
        {
            var movie = _movieRepo.GetMovies();
            return Ok(new ApiResponce() { Status = "success", Message = "Movies Retreved Successfully", Data = movie});
        }

        // GET api/<MovieController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Movie? movie= _movieRepo.FindMovie(id);
            if (movie == null) { return NotFound($"Movie OF Id {id} Doesn't Exist"); }

            return Ok(new ApiResponce() { Status = "success", Message = "Movie Retrived Successfully", Data = movie });
        }

        // POST api/<MovieController>
        [HttpPost]
        public IActionResult Post([FromBody] MovieViewModel mvm)
        {
            if (!ModelState.IsValid){ return BadRequest(); }
            //checking if movieCategoryExist
            MovieCategory? movieCategory = _mcRepo.FindMovieCategory(mvm.MovieCategory.Name);
            if (movieCategory==null){ return NotFound($"Movie Category With Name:'{mvm.MovieCategory.Name}' Doesn't Exist"); }
            //checking duplicate title of movie 
            Movie? m = _movieRepo.FindMovie(mvm.Title);
            if (movieCategory!=null){ return NotFound($"Movie With Title:'{mvm.Title}' Already Exist"); }
            Movie newMovie = _movieRepo.CreateMovie(new Movie()
            {
                //set props
                Title=mvm.Title
            });
            return CreatedAtAction(nameof(Get), new {id= });            
        }

        // PUT api/<MovieController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MovieController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
