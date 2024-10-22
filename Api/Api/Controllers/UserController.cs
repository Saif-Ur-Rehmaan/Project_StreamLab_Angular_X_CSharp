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
                return NotFound($"User of Id {id} Doesn't Exist");   
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
                return BadRequest($"Role with Name {user.Role.Name} Doesn't Exist");
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
            // Return the created user
            return CreatedAtAction(nameof(Get), new { id=newUser.Id},new ApiResponce { Status = "success", Message = "User Created Successfully", Data = u });
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UserViewModel user)
        {

            if (!ModelState.IsValid){return BadRequest();}
            //Finding user 
            User? u = _userRepo.FindUser(id);
            //Checking if User Exist
            if (u==null){return NotFound($"User of Id {id} Doesn't Exist");}
            
            //Making sure that Email is Unique
            User? u2= _userRepo.FindUser(user.Email,u.Id);
            if (u2 != null){return Conflict($"Duplicate Email Address; someone with This Email '{user.Email}' is already registered");}
            
            //checking role exist
            Role? role=_roleRepo.FindRole(user.Role.Name);

            if (role==null){return BadRequest($"invalid Role Name; Given role with  Name:{user.Role.Name} Doesn't Exist");}

            //updating data
            u.Role = role;
            u.UserName = user.UserName;
            u.Email = user.Email;
            u.Password = BCrypt.Net.BCrypt.EnhancedHashPassword(user.Password, 13); // Enhanced hash for verification
            u.FirstName = user.FirstName;
            u.LastName = user.LastName;
            
            User updatedUser = _userRepo.UpdateUser(u);

             
            return Ok(new ApiResponce { Status = "success", Message = "Users Updated Successfully", Data = updatedUser});

        }
        
        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = _userRepo.FindUser(id);
            if (user == null)
            {
                return NotFound($"User of Id {id} Doesn't Exist");
            }

            _userRepo.DeleteUser(user); // Assuming you have a DeleteUser method
            return Ok(new ApiResponce { Status = "success", Message = "Users Deleted Successfully", Data = user });

        }
    }
}
