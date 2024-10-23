using Api.CORE.Models;
using Api.CORE.ResponseModels;
using Api.CORE.ViewModels;
using Api.REPOSITORY.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController(IRoleRepository roleRepo) : ControllerBase
    {
        public IRoleRepository _roleRepo = roleRepo;

        // GET: api/<RoleController>
        [HttpGet]
        public IActionResult Get()
        {
            var roles = _roleRepo.GetRoles();
            return Ok(new ApiResponse { Status = "success", Message = "Roles Retreaved Successfully", Data = roles });

        }

        // GET api/<RoleController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Role? role = _roleRepo.FindRole(id);
            if (role==null)
            {
                return NotFound($"Role of Id {id} Doesn't Exist");
            }
            return Ok(new ApiResponse { Status = "success", Message = "Role Retreaved Successfully", Data = role});

        }

        // POST api/<RoleController>
        [HttpPost]
        public IActionResult Post([FromBody] RoleViewModel role)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            Role? roleExist = _roleRepo.FindRole(role.Name);
            if (roleExist!=null)
            {
                return Conflict("Duplicate Role Name");
            }
             
            Role res= _roleRepo.CreateRole(new Role() { Name = role.Name });

            return CreatedAtAction(nameof(Get), new { id = res.Id }, new ApiResponse
            {
                Status = "success",
                Message = "Role created successfully",
                Data = res
            });

        }

        // PUT api/<RoleController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] RoleViewModel role)
        {
            if (!ModelState.IsValid) { return BadRequest(); }

            //making  sure that role exist
            Role? r = _roleRepo.FindRole(id);
            if (r==null){ return NotFound($"Role of Id {id} Doesn't Exist"); }
            
            //making sure that role name is unique
            bool isRoleNameAlreadyExist = _roleRepo.FindRoleExcept(role.Name,id)!=null;
            if (isRoleNameAlreadyExist){return Conflict("Duplicate Role Name");}

            //updating role
            r.Name=role.Name ;
            Role newRole = _roleRepo.UpdateRole(r);
            return Ok(new ApiResponse { Status = "success", Message = "Role Updated Successfully", Data = newRole});

        }

        // DELETE api/<RoleController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //Checking Role Exist
            var role = _roleRepo.FindRole(id);
            if (role == null){return NotFound($"Role of Id {id} Doesn't Exist");}
            //Deleting Role
            var res=_roleRepo.DeleteRole(role);

            return Ok(new ApiResponse { Status = "success", Message = "Role Deleted Successfully", Data = res});

        }
    }
}
