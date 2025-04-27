using daily_stream_cms.Models;
using daily_stream_cms.Services;
using Microsoft.AspNetCore.Mvc;

namespace daily_stream_cms.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolesController : ControllerBase
    {
        private readonly RolesService _rolesServices;
        public RolesController(RolesService rolesServices)
        {
            _rolesServices = rolesServices;
        }
        [HttpGet]

        public IActionResult getRoles()
        {
            var roles= _rolesServices.getAllRoles();
            return Ok(roles);
        }

        [HttpPost]
        public IActionResult CreateRole(Role role)
        {
            var createdRole =  _rolesServices.CreateRole(role);
            return CreatedAtAction(nameof(getRoleById), new { id = createdRole.Id }, createdRole);
        }

        [HttpGet("{roleId}")]

        public IActionResult getRoleById(int roleId)
        {
            var role = _rolesServices.getRoleById(roleId);
            if (role == null)
            {
                return NotFound();
            }
            return Ok(role);
        }

        // Update a role
        [HttpPut("{roleId}")]
        public IActionResult UpdateRole(int roleId, Role updatedRole)
        {
            var existingRole = _rolesServices.getRoleById(roleId);
            if (existingRole == null)
            {
                return NotFound();
            }

            existingRole.Name = updatedRole.Name; // Update the fields you want
            _rolesServices.UpdateRole(existingRole);

            return Ok(existingRole);
        }

        // Delete a role
        [HttpDelete("{roleId}")]
        public IActionResult DeleteRole(int roleId)
        {
            var deleted = _rolesServices.DeleteRole(roleId);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}
