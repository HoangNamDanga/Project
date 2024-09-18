using apiVPP.Data;
using apiVPP.DTOs.Request;
using apiVPP.DTOs.Response;
using apiVPP.Models;
using apiVPP.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace apiVPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _service;
        public RoleController(IRoleService service)
        {
            _service = service;
        }

        [HttpGet("getAll")]
        public ActionResult<List<Role>> getAllRole()
        {
            var role = _service.getAllRole();
            if (role.Count <= 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(role);
            }
        }
        [HttpGet("{id}")]
        public ActionResult<Role> getRoleByID(int id)
        {
            var role = _service.getRoleById(id);
            if (role != null)
            {
                return Ok(role);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult<Role> AddAuthor([FromBody] Role request)
        {
            var roleAdd = _service.AddRoler(request);
            return Ok(roleAdd);
        }

        [HttpDelete("{id}")]
        public ActionResult<Role> deleteRole(int id)
        {
            var role = _service.DeleteRole(id);
            if (role != false)
            {
                return Ok(role);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPut("{id}")]
        public ActionResult<Role> updateRole([FromBody] Role request)
        {
            var roleUpdate = _service.UpdateRole(request);
            if (roleUpdate != null)
            {
                return Ok(roleUpdate);
            }
            else
            {
                return Conflict();
            }
        }
    }
}
