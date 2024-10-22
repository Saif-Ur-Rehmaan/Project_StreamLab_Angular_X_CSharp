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
    public class MovieCategoryController(IMovieCategoryRepository mcRepo) : ControllerBase
    {
        public IMovieCategoryRepository _mcRepo = mcRepo;
        // GET: api/<MovieCategoryController>
        [HttpGet]
        public IActionResult Get()
        {
            var movieCats = _mcRepo.GetMovieCategories();
            return Ok(new ApiResponce() { Status = "success", Message = "Movie Categories Retreved Successfully", Data = movieCats});
        }

        // GET api/<MovieCategoryController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            MovieCategory? mc=_mcRepo.FindMovieCategory(id);
            if (mc==null){return NotFound($"Movie Category OF Id {id} Doesn't Exist");}
            return Ok(new ApiResponce() { Status="success",Message="Movie Category Retrived Successfully",Data=mc});
        }

        // POST api/<MovieCategoryController>
        [HttpPost]
        public IActionResult Post([FromBody] MovieCategoryViewModel mcvm)
        {
            if (!ModelState.IsValid){ return BadRequest(); }

            //checking that the name of category is unique
            MovieCategory? mc = _mcRepo.FindMovieCategory(mcvm.Name);

            if (mc!=null){return Conflict($"Movie Category With name '{mcvm.Name}' already Exist ; duplicate Entries Not Allowed");}

            MovieCategory newMC = _mcRepo.CreateMovieCategory(new MovieCategory() { 
                Name = mcvm.Name 
            });
            return CreatedAtAction(nameof(Get), new { id = newMC.Id }, new ApiResponce
            {
                Status = "success",
                Message = "Movie Category created successfully",
                Data = newMC
            });

        }

        // PUT api/<MovieCategoryController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id,[FromBody] MovieCategoryViewModel mcvm)
        {
            if (!ModelState.IsValid) { return BadRequest(); }
            //checking if movie category exist
            MovieCategory? existingMC = _mcRepo.FindMovieCategory(id);
            if (existingMC == null) { return NotFound($"Movie Category With Id '{id}' doesn't Exist ;"); }
            
            //checking that the name of category is unique
            MovieCategory? mc = _mcRepo.FindMovieCategoryExcept(mcvm.Name,id);
            if (mc != null) { return Conflict($"Movie Category With name '{mcvm.Name}' already Exist ; duplicate Entries Not Allowed"); }

            //Updating Movie Category
            existingMC.Name=mcvm.Name;

            MovieCategory newMC = _mcRepo.UpdateMovieCategory(existingMC);


            return Ok(new ApiResponce() { Status = "success", Message = "Movie Category Updated Successfully", Data = newMC});

        }

        // DELETE api/<MovieCategoryController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //checking if movie category exist
            MovieCategory? existingMC = _mcRepo.FindMovieCategory(id);
            if (existingMC == null) { return NotFound($"Movie Category With Id '{id}' doesn't Exist ;"); }
            //deleting MovieCategory
            MovieCategory deletedCategory = _mcRepo.DeleteMovieCategory(existingMC);
            return Ok(new ApiResponce
            {
                Status = "success",
                Message = $"Movie Category with ID '{id}' deleted successfully",
                Data = deletedCategory
            });

        }

    }
}
