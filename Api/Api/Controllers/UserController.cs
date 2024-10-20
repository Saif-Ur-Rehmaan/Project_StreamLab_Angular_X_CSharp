using Api.CORE.Models;
using Api.CORE.ResponceModels;
using Api.CORE.ViewModels;
using Api.REPOSITORY.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserRepository userrepository, IRoleRepository roleRepository) : ControllerBase
    {
        private readonly IUserRepository _userRepo = userrepository;
        private readonly IRoleRepository _roleRepo = roleRepository;

        // GET: api/<UserController>
        [HttpGet]
        public IActionResult Get()
        {
            var users = _userRepo.GetUsers();
            return Ok(new ApiResponce{ Status="success",Message="Users Retreaved Successfully",Data=users});
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]

        public IActionResult Get(int id)
        {
             
            User? user = _userRepo.FindUser(id);
            if (user==null)
            {
                return NotFound();   
            }

            return Ok(new ApiResponce { Status = "success", Message = "User Retreaved Successfully", Data = user});

        }

        // POST api/<UserController>
        [HttpPost]
        public IActionResult Post([FromBody] UserViewModel user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            User? userExist = _userRepo.FindUser(user.Email);
            if (userExist !=null)
            {
                return Conflict("Duplicate Email Address");
            }
            // Find the role by name or create a new one if it doesn't exist
            Role? role = _roleRepo.FindRole(user.Role.Name)  ;
            if (role ==null)
            {
                return BadRequest();
            }

            User newUser = new()
            {
                Role = role,
                UserName = user.UserName,
                Email = user.Email,
                Password = BCrypt.Net.BCrypt.EnhancedHashPassword(user.Password, 13), // Enhanced hash for verification
                FirstName = user.FirstName,
                LastName = user.LastName,
            };

            User u=_userRepo.CreateUser(newUser);
            return Ok(new ApiResponce { Status = "success", Message = "Users Created Successfully", Data = u });
            // Return the created user
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UserViewModel user)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            User? userExist = _userRepo.FindUser(user.Email);
            if (userExist != null)
            {
                return Conflict("Duplicate Email Address");
            }
            var role=_roleRepo.FindRole(user.Role.Name);
            if (role==null)
            {
                return BadRequest();
            }
            User u = new() {
                Role = role,
                UserName = user.UserName,
                Email = user.Email,
                Password = BCrypt.Net.BCrypt.EnhancedHashPassword(user.Password, 13), // Enhanced hash for verification
                FirstName = user.FirstName,
                LastName = user.LastName,
            };
            User? updatedUser = _userRepo.UpdateUser(id, u);

            if (updatedUser == null)
            {
                return NotFound();
            }
            return Ok(new ApiResponce { Status = "success", Message = "Users Updated Successfully", Data = updatedUser});

        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = _userRepo.FindUser(id);
            if (user == null)
            {
                return NotFound();
            }

            _userRepo.DeleteUser(user); // Assuming you have a DeleteUser method
            return Ok(new ApiResponce { Status = "success", Message = "Users Deleted Successfully", Data = user });

        }
    }
}
