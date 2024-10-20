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
    public class RoleController(IRoleRepository roleRepo) : ControllerBase
    {
        public IRoleRepository _roleRepo = roleRepo;

        // GET: api/<RoleController>
        [HttpGet]
        public IActionResult Get()
        {
            var roles = _roleRepo.GetRoles();
            return Ok(new ApiResponce { Status = "success", Message = "Roles Retreaved Successfully", Data = roles });

        }

        // GET api/<RoleController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Role? role = _roleRepo.FindRole(id);
            if (role==null)
            {
                return NotFound();
            }
            return Ok(new ApiResponce { Status = "success", Message = "Role Retreaved Successfully", Data = role});

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

            Role newRole= new() {Name=role.Name};
            Role res= _roleRepo.CreateRole(newRole);

            return Ok(new ApiResponce { Status = "success", Message = "Role Created Successfully", Data = res });

        }

        // PUT api/<RoleController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] RoleViewModel role)
        {
            if (!ModelState.IsValid) { return BadRequest(); }

            Role? roleExist = _roleRepo.FindRole(role.Name);
            if (roleExist != null)
            {
                return Conflict("Duplicate Role Name");
            }
            Role Role = new() {Name=role.Name };
            Role? newRole = _roleRepo.UpdateRole(id,Role);
            if (newRole==null)
            { 
                return NotFound();
            }

            return Ok(new ApiResponce { Status = "success", Message = "Role Updated Successfully", Data = role});

        }

        // DELETE api/<RoleController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var role = _roleRepo.FindRole(id);

            if (role == null)
            {
                return NotFound();
            }

            var res=_roleRepo.DeleteRole(role);

            // Consider returning a more specific response based on your needs:
            return Ok(new ApiResponce { Status = "success", Message = "Role Deleted Successfully", Data = res});

        }
    }
}
