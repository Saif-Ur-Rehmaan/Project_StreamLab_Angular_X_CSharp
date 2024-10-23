using Api.CORE.Models;
using Api.CORE.ResponseModels;
using Api.CORE.ViewModels;
using Api.REPOSITORY.Interfaces;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchasedPackegesController(IPurchasedPackegeRepository ppRepo,IUserRepository userRepo,IPricingRepository pricingRepo) : ControllerBase
    {
        public IPurchasedPackegeRepository _ppRepo =ppRepo;
        public IPricingRepository _pricingRepo =pricingRepo;
        public IUserRepository _userRepo =userRepo;

        // GET: api/<PurchasedPackeges>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<PurchasedPackege> data=_ppRepo.GetPurchasedPackeges();
            return Ok(new ApiResponse() { Status = "success", Message = "Purchased Packeges Retreved Successfully", Data = data});
        }

        // GET api/<PurchasedPackeges>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            PurchasedPackege? pp= _ppRepo.FindPurchasedPackege(id);
            if (pp == null)
            {
                return NotFound($"Pricing of Id {id} Doesn't Exist");
            }
            return Ok(new ApiResponse() { Status = "success", Message = "Purchased Packege Retreved Successfully", Data = pp });

        }

        // POST api/<PurchasedPackeges>
        [HttpPost]
        public IActionResult Post([FromBody] PurchasedPackegeViewModel ppvm)
        {

            if (!ModelState.IsValid) { return BadRequest(); }
            //Checking if user And Pricing Exist
            User? user= _userRepo.FindUser(ppvm.UserEmail);
            Pricing? pricing= _pricingRepo.FindPricing(ppvm.PricingTitle);

            if (user==null || pricing==null)
            { 
               string message = (user, pricing) switch {
                    (null, null) => "User and pricing don't exist",
                    (not null, null) => "Pricing doesn't exist",
                    (null, not null) => "User doesn't exist",
                    _ => "Both user and pricing exist",
                };
                return Conflict(message);
            }

            //checking if same user already bought same packege 
            PurchasedPackege? pp = _ppRepo.FindPurchasedPackege(ppvm.UserEmail,ppvm.PricingTitle);
            if (pp!=null){ return Conflict($"User with email '{ppvm.UserEmail}' Already Bought the pricing of '{ppvm.PricingTitle}'"); }


            //creating new PP
            PurchasedPackege newPP = _ppRepo.CreatePurchasedPackege(new PurchasedPackege()
            {
                User = user,
                Pricing = pricing,
                Status = ppvm.Status
            });
            return CreatedAtAction(nameof(Get), new { id = newPP.Id }, new ApiResponse
            {
                Status = "success",
                Message = "Purchased Packeges created successfully",
                Data = newPP
            });
            
           
        }

        // PUT api/<PurchasedPackeges>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] PurchasedPackegeViewModel ppvm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            // Find the existing purchased package by id
            PurchasedPackege? existingPP = _ppRepo.FindPurchasedPackege(id);
            if (existingPP == null)
            {
                return NotFound($"Purchased Package with ID '{id}' not found");
            }

            // Checking if user and pricing exist
            User? user = _userRepo.FindUser(ppvm.UserEmail);
            Pricing? pricing = _pricingRepo.FindPricing(ppvm.PricingTitle);

            if (user == null || pricing == null)
            {
                string message = (user, pricing) switch
                {
                    (null, null) => "User and pricing don't exist",
                    (not null, null) => "Pricing doesn't exist",
                    (null, not null) => "User doesn't exist",
                    _ => "Unexpected error"
                };
                return Conflict(new { Status = "error", Message = message });
            }


            // Updating the existing purchased package
            existingPP.User = user;
            existingPP.Pricing = pricing;
            existingPP.Status = ppvm.Status;

            PurchasedPackege updatedPP= _ppRepo.UpdatePurchasedPackege(existingPP);

            return Ok(new ApiResponse
            {
                Status = "success",
                Message = "Purchased Package updated successfully",
                Data = updatedPP
            });
        }

        // DELETE api/<PurchasedPackeges>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Find the existing purchased package by id
            PurchasedPackege? existingPP = _ppRepo.FindPurchasedPackege(id);

            // If the purchased package does not exist, return a NotFound response
            if (existingPP == null)
            {
                return NotFound($"Purchased Package with ID '{id}' not found");
            }

            // Delete the purchased package
            PurchasedPackege deletedPP= _ppRepo.DeletePurchasedPackege(existingPP);

            // Return success response
            return Ok(new ApiResponse
            {
                Status = "success",
                Message = $"Purchased Package with ID '{id}' deleted successfully",
                Data=deletedPP
            });
        }

    }
}
