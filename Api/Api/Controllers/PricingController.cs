using System.Data;
using Api.CORE.Models;
using Api.CORE.ResponceModels;
using Api.CORE.ViewModels;
using Api.REPOSITORY.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricingController(IPricingRepository pricingRepo) : ControllerBase
    {
        public IPricingRepository _pricingRepo = pricingRepo;
        // GET: api/<PricingController>
        [HttpGet]   
        public IActionResult Get()
        {
            IEnumerable<Pricing> pricings= _pricingRepo.GetPricings();
            return Ok(new ApiResponce() { Status="success",Message="Pricing Retreved Successfully" ,Data=pricings});
        }

        // GET api/<PricingController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Pricing? pricing = _pricingRepo.FindPricing(id);
            if (pricing== null){return NotFound($"Pricing of Id {id} Doesn't Exist");}
            return Ok(new ApiResponce { Status = "success", Message = "Pricing Retreaved Successfully", Data = pricing});

        }

        // POST api/<PricingController>
        [HttpPost]
        public IActionResult Post([FromBody] PricingViewModel pricing)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            Pricing? _p = _pricingRepo.FindPricing(pricing.Title);
            if (_p!=null)
            {
                return Conflict($"Pricing With Name {pricing.Title} Already Exist. The Title Should Be Unique");
            }

            var newP = _pricingRepo.CreatePricing(new()
            {
                Title = pricing.Title,
                Price = pricing.Price,
                Features = pricing.Features,
                DiscountPercent = pricing.DiscountPercent,
                Duration = pricing.Duration
            });
            return CreatedAtAction(nameof(Get), new { id = newP.Id }, new ApiResponce
            {
                Status = "success",
                Message = "Pricing Created Successfully",
                Data = newP
            });
 

        }

        // PUT api/<PricingController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] PricingViewModel pricing)
        {
            if (!ModelState.IsValid) { return BadRequest(); }
            
            //CHecking Pricing Exist 
            Pricing? existingP = _pricingRepo.FindPricing(id);
            if (existingP==null){return NotFound($"Pricing of Id {id} Doesn't Exist");}
            
            //Updating Pricing
            existingP.Title = pricing.Title;
            existingP.Price = pricing.Price;
            existingP.Features = pricing.Features;
            existingP.DiscountPercent = pricing.DiscountPercent;
            existingP.Duration = pricing.Duration;
            
            Pricing newP= _pricingRepo.UpdatePricing(existingP);
            return Ok(new ApiResponce { Status = "success", Message = "Pricing Updated Successfully", Data = newP });

        }

        // DELETE api/<PricingController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Pricing? pricingExist = _pricingRepo.FindPricing(id);
            if (pricingExist == null)
            {
                return NotFound($"Pricing of Id {id} Doesn't Exist");

            }
            var res = _pricingRepo.DeletePricing(pricingExist);

            // Consider returning a more specific response based on your needs:
            return Ok(new ApiResponce { Status = "success", Message = "Pricing Deleted Successfully", Data = res});
        }

       
    }
}
